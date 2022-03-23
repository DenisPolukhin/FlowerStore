using FlowStoreBackend.Logic.Models;
using FlowStoreBackend.Logic.Models.User;

namespace FlowStoreBackend.Logic.Interfaces
{
    public interface IUsersService
    {
        Task<Result> SignUpAsync(SignUpModel signUpModel);
        Task<LoginResultModel> LogInAsync(LogInModel logInModel);

    }
}
