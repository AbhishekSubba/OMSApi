using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Net;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using System.Web.Configuration;

namespace OMSDB
{
    public class clsCommon
    {
        public static DataSet OrderInsert(int intOrderID, int intCustomerID, string strProductItemID, decimal dcmSubTotalFare, int intShipingAddressID, string strQuantitiesPerProductID)
        {
            string strResult = "";
            clsDB objDB = null;
            DataSet dstOutPut = null;
            string strErr = "";
            try
            {
                objDB = new clsDB();
                objDB.AddParameter("p_OrderID", intOrderID);
                objDB.AddParameter("p_CustomerID", intCustomerID);
                objDB.AddParameter("p_ProductItemIDs", strProductItemID, strProductItemID.Length);
                objDB.AddParameter("p_SubTotalFare", dcmSubTotalFare);
                objDB.AddParameter("p_ShipingAddressID", intShipingAddressID);
                objDB.AddParameter("p_OrderStatus", 0);
                objDB.AddParameter("p_QuantitiesPerProductID", strQuantitiesPerProductID, strQuantitiesPerProductID.Length);
                objDB.AddParameter("p_ErrMessage", strErr, strErr.Length,ParameterDirection.Output);
                dstOutPut = objDB.ExecuteSelect("spOrderInsertUpdate", CommandType.StoredProcedure, 0, ref strErr, "p_ErrMessage");
                if (strErr != "")
                    strResult = "Error:" + strErr;
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
            return dstOutPut;
        }
        public static DataSet DeleteOrder(int intOrderID, int intCustomerID, string strProductItemID, decimal dcmSubTotalFare, int intShipingAddressID, string strQuantitiesPerProductID)
        {
            string strResult = "";
            clsDB objDB = null;
            DataSet dstOutPut = null;
            string strErr = "";
            try
            {
                objDB = new clsDB();
                objDB.AddParameter("p_OrderID", intOrderID);
                objDB.AddParameter("p_CustomerID", intCustomerID);
                objDB.AddParameter("p_ProductItemIDs", strProductItemID, strProductItemID.Length);
                objDB.AddParameter("p_SubTotalFare", dcmSubTotalFare);
                objDB.AddParameter("p_ShipingAddressID", intShipingAddressID);
                objDB.AddParameter("p_OrderStatus", 2);
                objDB.AddParameter("p_QuantitiesPerProductID", strQuantitiesPerProductID, strQuantitiesPerProductID.Length);
                objDB.AddParameter("p_ErrMessage", strErr, strErr.Length, ParameterDirection.Output);
                dstOutPut = objDB.ExecuteSelect("spOrderInsertUpdate", CommandType.StoredProcedure, 0, ref strErr, "p_ErrMessage");
                if (strErr != "")
                    strResult = "Error:" + strErr;
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
            return dstOutPut;
        }
        public static DataSet UpdateOrder(int intOrderID, int intOrderStatusID)
        {
            string strResult = "";
            clsDB objDB = null;
            DataSet dstOutPut = null;
            string strErr = "";
            try
            {
                objDB = new clsDB();
                objDB.AddParameter("p_OrderID", intOrderID);
                objDB.AddParameter("p_OrderStatusID", intOrderStatusID);
                objDB.AddParameter("p_ErrMessage", strErr, strErr.Length, ParameterDirection.Output);
                dstOutPut = objDB.ExecuteSelect("spOrderUpdate", CommandType.StoredProcedure, 0, ref strErr, "p_ErrMessage");
                if (strErr != "")
                    strResult = "Error:" + strErr;
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
            return dstOutPut;
        }

        public static DataSet OrderView(int intOrderID, int intCustomerID)
        {
            string strResult = "";
            clsDB objDB = null;
            DataSet dstOutPut = null;
            string strErr = "";
            try
            {
                objDB = new clsDB();
                objDB.AddParameter("p_OrderID", intOrderID);
                objDB.AddParameter("p_CustomerID", intCustomerID);
                objDB.AddParameter("p_ErrMessage", strErr, strErr.Length, ParameterDirection.Output);
                dstOutPut = objDB.ExecuteSelect("spOrderView", CommandType.StoredProcedure, 0, ref strErr, "p_ErrMessage");
                if (strErr != "")
                    strResult = "Error:" + strErr;
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
            return dstOutPut;
        }
    }
}
