﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
// 
namespace SiemensHR.edoc {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="UserSoap", Namespace="http://tempuri.org/")]
    public class User : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public User() {
            this.Url = "http://localhost/UserWebService/User.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/InsertUpdateUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool InsertUpdateUser(string mark, string name, string email, string telephone, string personal_data, string user_name, string password, string sid, bool deleted) {
            object[] results = this.Invoke("InsertUpdateUser", new object[] {
                        mark,
                        name,
                        email,
                        telephone,
                        personal_data,
                        user_name,
                        password,
                        sid,
                        deleted});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginInsertUpdateUser(string mark, string name, string email, string telephone, string personal_data, string user_name, string password, string sid, bool deleted, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("InsertUpdateUser", new object[] {
                        mark,
                        name,
                        email,
                        telephone,
                        personal_data,
                        user_name,
                        password,
                        sid,
                        deleted}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndInsertUpdateUser(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DeleteUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool DeleteUser(string marca) {
            object[] results = this.Invoke("DeleteUser", new object[] {
                        marca});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDeleteUser(string marca, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("DeleteUser", new object[] {
                        marca}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndDeleteUser(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
    }
}