using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
//using System.Web.Mvc;
using System.Web.Http;
using System.Data;
using Newtonsoft.Json;
using OMSDB;
using Newtonsoft.Json.Linq;
using System.Web.Configuration;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace OMSApi.Controllers
{
    public class OrderController : ApiController
    {
        //Get All Order
        public delegate string dlgSendEmail(int intOrderID, int intCustomerID);

        [HttpPost]
        public OrderStatus[] AddOrder(int intOrderID, int intCustomerID,string strProductItemID,decimal dcmSubTotalFare ,int intShipingAddressID ,string strQuantitiesPerProductID) 
        {
            //if (!IsAuthentic(AgentID, KeyCode)) { return null; }
            string strResult = "";
            DataSet dstOutPut = null;
            OrderStatus objBS = new OrderStatus();
            OrderStatus[] objArr = null;
            ArrayList al = new ArrayList();
            try
            {
                OrderStatus ord;
                dstOutPut = OMSDB.clsCommon.OrderInsert(intOrderID, intCustomerID, strProductItemID, dcmSubTotalFare, intShipingAddressID, strQuantitiesPerProductID);
                if (dstOutPut != null && dstOutPut.Tables.Count > 0 && dstOutPut.Tables[0].Columns.Count > 1)
                {
                    foreach (DataRow dr in dstOutPut.Tables[0].Rows)
                    {
                        ord = new OrderStatus();
                        ord.OrderID = Convert.ToInt32(dr["OrderID"]);
                        ord.CustomerName = dr["CustomerName"].ToString();
                        ord.status = dr["status"].ToString();
                        ord.SubTotalFare = Convert.ToDouble(dr["SubTotalFare"]);
                        ord.message = dr["Errmessage"].ToString();

                        al.Add(ord);
                    }
                    objArr = (OrderStatus[])al.ToArray(typeof(OrderStatus));
                    try
                    {
                        dlgSendEmail email = new dlgSendEmail(SendEmail);
                        email.BeginInvoke(Convert.ToInt32(dstOutPut.Tables[0].Rows[0]["OrderID"]), intCustomerID,null,null);
                    }
                    catch(Exception xe)
                    {

                    }
                }
                else
                {
                    foreach (DataRow dr in dstOutPut.Tables[0].Rows)
                    {
                        ord = new OrderStatus();
                        ord.message = dr["Errmessage"].ToString();
                        al.Add(ord);
                    }
                    objArr = (OrderStatus[])al.ToArray(typeof(OrderStatus));
                }
                return objArr;
            }
            catch(Exception ex)
            {
                strResult = ex.Message;
            }
            return null;
        }
        [HttpPost]
        public OrderStatus[] DeleteOrder(int intOrderID, int intCustomerID, string strProductItemID, decimal dcmSubTotalFare, int intShipingAddressID, string strQuantitiesPerProductID)
        {
            //if (!IsAuthentic(AgentID, KeyCode)) { return null; }
            string strResult = "";
            DataSet dstOutPut = null;
            OrderStatus objBS = new OrderStatus();
            OrderStatus[] objArr = null;
            ArrayList al = new ArrayList();
            try
            {
                OrderStatus ord;
                dstOutPut = OMSDB.clsCommon.DeleteOrder(intOrderID, intCustomerID, strProductItemID, dcmSubTotalFare, intShipingAddressID, strQuantitiesPerProductID);
                if (dstOutPut != null && dstOutPut.Tables.Count > 0)
                {
                        foreach (DataRow dr in dstOutPut.Tables[0].Rows)
                        {
                            ord = new OrderStatus();
                            ord.OrderID = Convert.ToInt32(dr["OrderID"]);
                            ord.CustomerName = dr["CustomerName"].ToString();
                            ord.status = dr["status"].ToString();
                            ord.SubTotalFare = Convert.ToDouble(dr["SubTotalFare"]);
                            ord.message = dr["Errmessage"].ToString();

                            al.Add(ord);
                        }
                        objArr = (OrderStatus[])al.ToArray(typeof(OrderStatus));
                }
                return objArr;
            }
            catch(Exception ex)
            {
                strResult = ex.Message;
            }
            return null;
        }
        [HttpPost]
        public OrderStatus[] UpdateOrder(int intOrderID, int intOrderStatusID)
        {
            //if (!IsAuthentic(AgentID, KeyCode)) { return null; }
            string strResult = "";
            DataSet dstOutPut = null;
            OrderStatus objBS = new OrderStatus();
            OrderStatus[] objArr = null;
            ArrayList al = new ArrayList();
            try
            {
                OrderStatus ord;
                dstOutPut = OMSDB.clsCommon.UpdateOrder(intOrderID, intOrderStatusID);
                if (dstOutPut != null && dstOutPut.Tables.Count > 0 && dstOutPut.Tables[0].Columns.Count > 1)
                {
                    foreach (DataRow dr in dstOutPut.Tables[0].Rows)
                    {
                        ord = new OrderStatus();
                        ord.OrderID = Convert.ToInt32(dr["OrderID"]);
                        ord.CustomerName = dr["CustomerName"].ToString();
                        ord.status = dr["status"].ToString();
                        ord.SubTotalFare = Convert.ToDouble(dr["SubTotalFare"]);
                        ord.message = dr["Errmessage"].ToString();

                        al.Add(ord);
                    }
                    objArr = (OrderStatus[])al.ToArray(typeof(OrderStatus));

                }
                else
                {
                    foreach (DataRow dr in dstOutPut.Tables[0].Rows)
                    {
                        ord = new OrderStatus();
                        ord.message = dr["Errmessage"].ToString();

                        al.Add(ord);
                    }
                    objArr = (OrderStatus[])al.ToArray(typeof(OrderStatus));
                }
                return objArr;
            }
            catch(Exception ex)
            {
                strResult = ex.Message;
            }
            return null;
        }
        [HttpGet]
        public OrderView[] OrderView(int intOrderID, int intCustomerID)
        {
            //if (!IsAuthentic(AgentID, KeyCode)) { return null; }
            string strResult = "";
            DataSet dstOutPut = null;
            OrderView objBS = new OrderView();
            OrderView[] objArr = null;
            ArrayList al = new ArrayList();
            try
            {
                OrderView ord;
                dstOutPut = OMSDB.clsCommon.OrderView(intOrderID, intCustomerID);
                if (dstOutPut != null && dstOutPut.Tables.Count > 0 && dstOutPut.Tables[0].Columns.Count > 1)
                {
                    foreach (DataRow dr in dstOutPut.Tables[0].Rows)
                    {
                        ord = new OrderView();
                        ord.OrderID = Convert.ToInt32(dr["OrderID"]);
                        ord.CustomerName = dr["CustomerName"].ToString();
                        ord.status = dr["status"].ToString();
                        ord.SubTotalFare = Convert.ToDouble(dr["SubTotalFare"]);
                        ord.message = dr["Errmessage"].ToString();
                        ord.Shiping_Street1 = (dr["Shiping_Street1"]).ToString();
                        ord.Shiping_Street2 = dr["Shiping_Street2"].ToString();
                        ord.Shiping_City = dr["Shiping_City"].ToString();
                        ord.Shiping_State = dr["Shiping_State"].ToString();
                        ord.Shiping_Country = dr["Shiping_Country"].ToString();
                        ord.Shiping_Postal_Code = Convert.ToInt32(dr["Shiping_Postal_Code"]);
                        ord.QuantitiesCount = dr["QuantitiesPerProductID"].ToString();
                        ord.MobileNo = dr["MobileNo"].ToString();
                        ord.EmailID = dr["EmailID"].ToString();

                        al.Add(ord);
                    }
                    objArr = (OrderView[])al.ToArray(typeof(OrderView));
                }
                else
                {
                    foreach (DataRow dr in dstOutPut.Tables[0].Rows)
                    {
                        ord = new OrderView();
                        ord.message = dr["Errmessage"].ToString();
                        al.Add(ord);
                    }
                    objArr = (OrderView[])al.ToArray(typeof(OrderView));
                }
                return objArr;
            }
            catch(Exception ex)
            {
                strResult = ex.Message;
            }
            return null;
        }
        public string SendEmail(int intOrderID, int intCustomerID)
        {
            string strBody = "";
            string strSubject = "";
            string strErr = "";
            string strOrderID = "";
            string strCustEmail = "";
            string strSenderEmailID = "";
            string strSenderEmailPwd = "";
            StreamReader sdr = null;
            string strResult = "DONE";
            try
            {
                //string strFilePath = System.Web.Configuration.WebConfigurationManager.AppSettings["FilePath"];
                //sdr = new StreamReader(strFilePath);
                //strBody = sdr.ReadToEnd();
                //if (sdr != null)
                //    sdr.Close();
                strBody = SetEmailBody(strBody, intOrderID, intCustomerID, ref strSubject, ref strErr, ref strOrderID, ref strCustEmail, ref strSenderEmailID, ref strSenderEmailPwd);
                if (strErr == "")
                {
                    //strCustEmail = "jaldeep.tarsariya@travelyaari.com";
                    if (strSenderEmailID != "" && strCustEmail != "")
                        SendMail(strSenderEmailID, strSenderEmailPwd, strCustEmail, strSubject, strBody, strBody, strOrderID);
                    else
                    {
                        if (strCustEmail == "")
                            strResult = "Error:" + "Customer EmailID not provided";
                        else if (strSenderEmailID == "")
                            strResult = "Error:" + "Sender EmailID not provided";
                    }
                }
                else
                    strResult = "Error:" + strErr;
            }
            catch (Exception ex)
            {
                strResult = "Error:" + ex.Message;
            }
            finally
            { }
            return strResult;
        }

        private string SetEmailBody(string strBody, int intOrderID, int intCustomerID, ref string strSubject,
            ref string strErr, ref string strOrderID, ref string strCustEmail, ref string strSenderEmailID, ref string strSenderEmailPwd)
        {
            clsDB objDB = null;
            string strResult;
            DataSet dstOutPut;
            StringBuilder str = new StringBuilder(strBody);
            StringBuilder strText = new StringBuilder("");
            try
            {
                objDB = new clsDB();
                objDB.AddParameter("p_intOrderID", intOrderID);
                objDB.AddParameter("p_intCustomerID", intCustomerID);
                dstOutPut = objDB.ExecuteSelect("spOrderDetailsEmail", CommandType.StoredProcedure, 0, ref strErr, "p_ErrMsg");
                if (strErr != "")
                    strResult = "Error:" + strErr;
                if (dstOutPut != null && dstOutPut.Tables.Count > 0)
                {
                    strOrderID = Convert.ToString(dstOutPut.Tables[0].Rows[0]["OrderID"]);
                    strCustEmail = Convert.ToString(dstOutPut.Tables[0].Rows[0]["CustomerEmailID"]);
                    strSenderEmailID = Convert.ToString(dstOutPut.Tables[0].Rows[0]["SenderEmailID"]);
                    strSenderEmailPwd = System.Web.Configuration.WebConfigurationManager.AppSettings["SenderPwd"];
                    strSubject = Convert.ToString(dstOutPut.Tables[0].Rows[0]["CustomerName"]) + " Oredr Itinerary :: Order ID " + Convert.ToString(dstOutPut.Tables[0].Rows[0]["OrderID"]);

                    if (dstOutPut.Tables.Count > 0 && dstOutPut.Tables[0].Rows.Count > 0)
                    {
                       
                        strText.Append("<tr><td >Your Order is Booked Successfully</td></tr>");
                         
                    }

                    //str= str.Append("<table width='600px' border='0'>" + strText.ToString() + "</table>").ToString();

                    strBody = strText.ToString();

                }
            }
            catch (Exception ex)
            {
            }


            return strBody;
        }
            private void SendMail(string strSenderEmailID, string strSenderEmailPwd, string strTo, string strSubject, string strBody, string strAttachment, string strOrderID)
        {
            MailMessage message = null;
            try
            {
                string EmailId = strSenderEmailID;
                string smtpServer = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPServer"];
                string smtpPort = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPPort"];
                string EmailPassword = strSenderEmailPwd;

                SmtpClient smtp = new SmtpClient(smtpServer, Convert.ToInt32(smtpPort));
                message = new MailMessage();

                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Timeout = 60000;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential(EmailId, EmailPassword);
                message.From = new MailAddress(EmailId);
                string[] strArrEmails = strTo.Split(',');
                foreach (string strToEmail in strArrEmails)
                    message.To.Add(new MailAddress(strToEmail));
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Body = strBody;
                message.IsBodyHtml = true;
                message.Subject = strSubject;
                smtp.Send(message);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (message != null)
                    message.Dispose();
            }
        }
    }
}
