using AutoMapper;
using Common.BaseDto; 

namespace Common.CQRS
{
    public abstract class Command<TReq>
    { 
        protected readonly IMapper Mapper;
        protected readonly IDatabaseContext DatabaseContext;

        protected Command(IDatabaseContext databaseContext, IMapper mapper)
        {
            DatabaseContext = databaseContext;
            Mapper = mapper;
        }

        public abstract Response Execute(TReq request);
        
    }

 
}
