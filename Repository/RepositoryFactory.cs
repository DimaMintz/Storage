using Storage5.Models;

namespace Storage5.Repository
{
    public static class RepositoryFactory
    {
       public static T CreateRepositoryObject<T>(OrdersContext context)
        {
            if(typeof(T) == typeof(ICustomerRepository))
            {
                return (T)(ICustomerRepository)new ApplicationRepository(context);
            }
            if (typeof(T) == typeof(IOrderRepository))
            {
                return (T)(IOrderRepository)new ApplicationRepository(context);
            }
            if (typeof(T) == typeof(IProductRepository))
            {
                return (T)(IProductRepository)new ApplicationRepository(context);
            }
            if (typeof(T) == typeof(IReportRepository))
            {
                return (T)(IReportRepository)new ApplicationRepository(context);
            }
            if (typeof(T) == typeof(IStatusRepository))
            {
                return (T)(IStatusRepository)new ApplicationRepository(context);
            }
            else
            {
                return default;
            }

        }
    }
}