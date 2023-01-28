namespace BLL;
using BOL;
using DAL;
using System.Collections.Generic;

public class AccountManager
{
   
    public static AccountManager _ref=null;
    
    
    private AccountManager(){

    }

public static AccountManager GetAccountManager(){
        if(_ref==null){
            _ref=new AccountManager();
        }
        return _ref;

    }
  public bool LoginCheck(string email,string password)
  {
         bool status= MySqlRepository.LoginCheck(email,password);
         return status;
}


    

    

}
