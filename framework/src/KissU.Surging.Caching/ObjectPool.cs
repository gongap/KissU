using System;
using System.Collections.Generic;
using System.Threading;
using KissU.Surging.Caching.Utilities;

namespace KissU.Surging.Caching
{
    /// <summary>
    /// ObjectPool.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T>
    {
        /// <summary>
        /// 构造一个对象池
        /// </summary>
        /// <param name="func">用来初始化对象的函数</param>
        /// <param name="minSize">对象池下限</param>
        /// <param name="maxSize">对象池上限</param>
        public ObjectPool(Func<T> func, int minSize = 100, int maxSize = 100)
        {
            Check.CheckCondition(() => func == null, "func");
            Check.CheckCondition(() => minSize < 0, "minSize");
            Check.CheckCondition(() => maxSize < 0, "maxSize");
            if (minSize > 0)
                this.minSize = minSize;
            if (maxSize > 0)
                this.maxSize = maxSize;
            for (var i = 0; i < this.minSize; i++)
            {
                queue.Enqueue(func());
            }

            currentResource = this.minSize;
            tryNewObject = this.minSize;
            this.func = func;
        }

        /// <summary>
        /// 从对象池中取一个对象出来, 执行完成以后会自动将对象放回池中
        /// </summary>
        /// <returns>T.</returns>
        public T GetObject()
        {
            var t = default(T);
            try
            {
                if (tryNewObject < maxSize)
                {
                    Interlocked.Increment(ref tryNewObject);
                    t = func();
                    // Interlocked.Increment(ref this.currentResource);
                }
                else
                {
                    Enter();
                    t = queue.Dequeue();
                    Leave();
                    Interlocked.Decrement(ref currentResource);
                }

                return t;
            }
            finally
            {
                Enter();
                queue.Enqueue(t);
                Leave();
                Interlocked.Increment(ref currentResource);
            }
        }

        #region

        private int isTaked;
        private readonly Queue<T> queue = new Queue<T>();
        private readonly Func<T> func;
        private int currentResource;
        private int tryNewObject;
        private readonly int minSize = 1;
        private readonly int maxSize = 50;

        #endregion

        #region private methods

        private void Enter()
        {
            while (Interlocked.Exchange(ref isTaked, 1) != 0)
            {
            }
        }

        private void Leave()
        {
            Interlocked.Exchange(ref isTaked, 0);
        }

        #endregion
    }
}