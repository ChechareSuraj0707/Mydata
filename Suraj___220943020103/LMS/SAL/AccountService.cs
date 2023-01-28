namespace SAL;
using BOL;
using BLL;

public class AccountService
{
    public bool LoginCheck (string email,string password){
        AccountManager theManager=AccountManager.GetAccountManager();
        bool status=theManager.LoginCheck(email,password);
        return status;
         
    }

    
}