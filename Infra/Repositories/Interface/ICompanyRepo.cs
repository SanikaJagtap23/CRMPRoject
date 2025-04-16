using Infra.Detos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interface
{
    public interface ICompanyRepo
    {
        Task<LoginResultDeto> Login(LoginDto rec);
        Task<RepoResultDto> ChangePassword(ChangePasswordDto rec, Int64 id);

        Task<EditProfileDeto> GetProfile(Int64 id);
        Task<RepoResultDto> EditProfile(EditProfileDeto rec, Int64 id);

    }
}
