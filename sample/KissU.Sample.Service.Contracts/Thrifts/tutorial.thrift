// thrift -r -gen netstd tutorial.thrift
namespace netstd ThriftContracts

service Calculator{
  i32 Add(1:i32 num1, 2:i32 num2)
  string SayHello();
}