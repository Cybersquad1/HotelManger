using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using HotelDBA;
using HotelModels;

namespace HotelLogic
{
    /// <summary>
    /// 执行登陆退出等过程
    /// </summary>
    public class LoginManger
    {
        /// <summary>
        /// 检查帐号密码是否匹配
        /// </summary>
        /// <param name="account">需要检查的帐号</param>
        /// <param name="psw">需要检测的密码</param>
        /// <returns>true为匹配，false为不匹配</returns>
        public static bool CheckAccPsw(string account,string psw)
        {
            string enpsw = EncryPsw(psw);

            return OperatorListService.VailPassword(account, enpsw);
        }

        /// <summary>
        /// 登陆进程
        /// </summary>
        /// <param name="account">登陆账号</param>
        /// <param name="psw">登录密码</param>
        /// <returns>返回0为登陆成功，-404为账户密码错误，-1为被禁用无法登陆</returns>
        public static int LoginIn(string account,string psw)
        {
            if(CheckAccPsw(account,psw)==true)
            {
                OperatorList node = OperatorListService.FindOperatorByID(-1, "", account, 3);
                if(node.Enable==false)
                {
                    return -1;
                }
                LoginInfo.Account = account;
                LoginInfo.DegreeLevel = node.AuthDegree;
                LoginInfo.OperID = node.OperID;
                LoginInfo.Name = node.OperName;
                OperatorListService.ChangeOperator(node.OperID, node.OperName, node.AuthDegree, node.LogInCount + 1, node.LoginAccount, "", true, 3);
            }
            else
            {
                return -404;
            }

            return 0;
        }

        /// <summary>
        /// 账户退出
        /// </summary>
        public static void LogOut()
        {
            LoginInfo.Init();
        }


        private static string EncryPsw(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));

            return BitConverter.ToString(output).Replace("-", "");
        }
    }
}
