using Infra.Detos;
using Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class CompanyUserRepo: ICompanyRepo
    {
        CRMContext cntx;
        public CompanyUserRepo(CRMContext cntx )
        {
            this.cntx = cntx;
        }
        public async Task<RepoResultDto> ChangePassword(ChangePasswordDto rec, long id)
        {
            RepoResultDto res = new RepoResultDto();
            if (rec.NewPassword != rec.ConfirmPassword)
            {
                res.IsSuccess = false;
                res.Message = "Password and Password are Not Same!";
                return res;
            }
            try
            {
                var srec = await this.cntx.CompanyUsers.FindAsync(id);
                if (srec.Password != rec.OldPassword)
                {
                    res.IsSuccess = false;
                    res.Message = "Password and Old Password are Not Same!";
                    return res;
                }
                srec.Password = rec.NewPassword;
                await this.cntx.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Password Changed!!!!";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }
        public async Task<RepoResultDto> EditProfile(EditProfileDeto rec, long id)
        {
            RepoResultDto res = new RepoResultDto();
            try
            {
                var oldrec = await this.cntx.CompanyUsers.FindAsync(id);
                oldrec.MobileNumber = rec.MobileNO;
                oldrec.EmailID = rec.EmailID;
                await this.cntx.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Profile Edited!!!!!!";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }

            return res;
        }



        public async Task<EditProfileDeto> GetProfile(long id)
        {
            var res = from t in this.cntx.CompanyUsers
                      where t.CompanyUserID == id
                      select new EditProfileDeto
                      {
                          EmailID = t.EmailID,
                          MobileNO = t.MobileNumber,
                         
                      };
            return await res.FirstOrDefaultAsync();
        }

       

       public async Task<LoginResultDeto> Login(LoginDto rec)
        {
            LoginResultDeto res = new LoginResultDeto();
            var srec = await this.cntx.CompanyUsers.SingleOrDefaultAsync(p => p.UserName == rec.UserName && p.Password == rec.Password);

            if (srec != null)
            {
                res.IsLoggedIn = true;
                res.LoggedInID = srec.CompanyUserID;
                res.LoggedInName = srec.UserName;
            }
            else
            {
                res.IsLoggedIn = false;
                res.Message = "Invalid Email Id or Password!";
            }

            return res;
        }
    }
    }



    




    

