﻿/// *************************************************************************************************
///	|| Creation History ||
///	-------------------------------------------------------------------------------------------------
///	Copyright		:	Copyright© MAHEDEE.NET. All rights reserved.
///	NameSpace		:	VS13CR11.App_Code.DAL
/// Class           :   DesignationDAL
/// Inherits        :   None
///	Author			:	Md. Mahedee Hasan
///	Purpose			:	
///	Creation Date	:	30/11/2015
/// ==================================================================================================
///  || Modification History ||
///  -------------------------------------------------------------------------------------------------
///  Sl No.	Date:		Author:			Ver:	Area of Change:

///	**************************************************************************************************

using System;
using System.Data;
using VS13CR11.App_Code.DAL;


namespace VS13CR11.App_Code.BLL
{
    public class DesignationBLL
    {
        public DataTable GetDesignationAll()
        {
            DesignationDAL objDesignationDAL = new DesignationDAL();
            try
            {
                return objDesignationDAL.GetDesignationAll();
            }
            catch(Exception exp)
            {
                throw (exp);
            }
        }
    }
}