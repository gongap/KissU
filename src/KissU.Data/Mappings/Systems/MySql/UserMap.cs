﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Domain.Systems.Models;

namespace KissU.Data.Mappings.Systems.MySql 
{
    /// <summary>
    /// 用户映射配置
    /// </summary>
    public class UserMap : Util.Datas.Ef.MySql.AggregateRootMap<User> 
	{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<User> builder ) 
		{
            builder.ToTable( "Systems.User" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<User> builder ) 
		{
            //
            builder.Property(t => t.Id)
                .HasColumnName("UserId");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}