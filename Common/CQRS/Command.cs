using Common.BaseDto; 

namespace Common.CQRS
{
    public interface ICommand<TReq>
    {
       Response Execute(Request<TReq> request);
    } 
    public interface ICommand
    {
       Response Execute();
    } 
}
