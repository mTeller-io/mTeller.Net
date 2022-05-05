using System;
using System.Threading;
using Platform.Model;

namespace Platform.Interface
{
    public interface IAPIService
    {
        Task<string> GetAsync(APIRequestData apiRequestData);
        Task<string> PostAsync(APIRequestData apiRequestData);
        Task PutAsync(APIRequestData apiRequestData);
        Task DeleteAsync(int Id);
    }
}