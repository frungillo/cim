//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CIM.ServiceNpk {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceControlloImpiantiSoap", Namespace="http://srv.anm.it/npk")]
    public partial class ServiceControlloImpianti : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public ServiceControlloImpianti() {
            this.Url = "http://srv.anm.it/npk/ServiceControlloImpianti.asmx";
        }
        
        public ServiceControlloImpianti(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/ControlloCredenziali", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Utente ControlloCredenziali(string imei) {
            object[] results = this.Invoke("ControlloCredenziali", new object[] {
                        imei});
            return ((Utente)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginControlloCredenziali(string imei, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ControlloCredenziali", new object[] {
                        imei}, callback, asyncState);
        }
        
        /// <remarks/>
        public Utente EndControlloCredenziali(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Utente)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/GetOperatore", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Operatore GetOperatore(string coddip) {
            object[] results = this.Invoke("GetOperatore", new object[] {
                        coddip});
            return ((Operatore)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetOperatore(string coddip, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetOperatore", new object[] {
                        coddip}, callback, asyncState);
        }
        
        /// <remarks/>
        public Operatore EndGetOperatore(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Operatore)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/GetCommessa", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Commesse GetCommessa(int idCommessa) {
            object[] results = this.Invoke("GetCommessa", new object[] {
                        idCommessa});
            return ((Commesse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetCommessa(int idCommessa, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetCommessa", new object[] {
                        idCommessa}, callback, asyncState);
        }
        
        /// <remarks/>
        public Commesse EndGetCommessa(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Commesse)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/GetCommesseByOperatore", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Commesse[] GetCommesseByOperatore(Operatore op) {
            object[] results = this.Invoke("GetCommesseByOperatore", new object[] {
                        op});
            return ((Commesse[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetCommesseByOperatore(Operatore op, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetCommesseByOperatore", new object[] {
                        op}, callback, asyncState);
        }
        
        /// <remarks/>
        public Commesse[] EndGetCommesseByOperatore(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Commesse[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/RegisterDeviceID", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool RegisterDeviceID(string deviceId, string coddip) {
            object[] results = this.Invoke("RegisterDeviceID", new object[] {
                        deviceId,
                        coddip});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginRegisterDeviceID(string deviceId, string coddip, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("RegisterDeviceID", new object[] {
                        deviceId,
                        coddip}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndRegisterDeviceID(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/GetoperatoriBySquadra", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Operatore[] GetoperatoriBySquadra(Squadre squadra) {
            object[] results = this.Invoke("GetoperatoriBySquadra", new object[] {
                        squadra});
            return ((Operatore[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetoperatoriBySquadra(Squadre squadra, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetoperatoriBySquadra", new object[] {
                        squadra}, callback, asyncState);
        }
        
        /// <remarks/>
        public Operatore[] EndGetoperatoriBySquadra(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Operatore[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/GetAttivitaByIdLavoro", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Attivita[] GetAttivitaByIdLavoro(int idLavoro) {
            object[] results = this.Invoke("GetAttivitaByIdLavoro", new object[] {
                        idLavoro});
            return ((Attivita[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAttivitaByIdLavoro(int idLavoro, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAttivitaByIdLavoro", new object[] {
                        idLavoro}, callback, asyncState);
        }
        
        /// <remarks/>
        public Attivita[] EndGetAttivitaByIdLavoro(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Attivita[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/SalvaStatoAttivitaCommessa", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SalvaStatoAttivitaCommessa(Commesse commessa) {
            object[] results = this.Invoke("SalvaStatoAttivitaCommessa", new object[] {
                        commessa});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSalvaStatoAttivitaCommessa(Commesse commessa, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SalvaStatoAttivitaCommessa", new object[] {
                        commessa}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndSalvaStatoAttivitaCommessa(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/SendAndroidNotificationByList", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SendAndroidNotificationByList(Operatore[] utenti, string msg, string titolo) {
            object[] results = this.Invoke("SendAndroidNotificationByList", new object[] {
                        utenti,
                        msg,
                        titolo});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSendAndroidNotificationByList(Operatore[] utenti, string msg, string titolo, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SendAndroidNotificationByList", new object[] {
                        utenti,
                        msg,
                        titolo}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndSendAndroidNotificationByList(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/SendAndroidNotificationByCommessa", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SendAndroidNotificationByCommessa(Commesse commessa) {
            object[] results = this.Invoke("SendAndroidNotificationByCommessa", new object[] {
                        commessa});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSendAndroidNotificationByCommessa(Commesse commessa, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SendAndroidNotificationByCommessa", new object[] {
                        commessa}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndSendAndroidNotificationByCommessa(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://srv.anm.it/npk/SendAndroidNotificationByString", RequestNamespace="http://srv.anm.it/npk", ResponseNamespace="http://srv.anm.it/npk", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SendAndroidNotificationByString(string Matricola, string msg, string titolo, int tipo, string commessa) {
            object[] results = this.Invoke("SendAndroidNotificationByString", new object[] {
                        Matricola,
                        msg,
                        titolo,
                        tipo,
                        commessa});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSendAndroidNotificationByString(string Matricola, string msg, string titolo, int tipo, string commessa, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SendAndroidNotificationByString", new object[] {
                        Matricola,
                        msg,
                        titolo,
                        tipo,
                        commessa}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndSendAndroidNotificationByString(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://srv.anm.it/npk")]
    public partial class Utente {
        
        /// <remarks/>
        public string Matricola;
        
        /// <remarks/>
        public string Nome;
        
        /// <remarks/>
        public string Cognome;
        
        /// <remarks/>
        public string NumTel;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://srv.anm.it/npk")]
    public partial class Squadre {
        
        /// <remarks/>
        public int Id;
        
        /// <remarks/>
        public string Descrizione;
        
        /// <remarks/>
        public string Area;
        
        /// <remarks/>
        public string Note;
        
        /// <remarks/>
        public Operatore[] Operatori;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://srv.anm.it/npk")]
    public partial class Operatore {
        
        /// <remarks/>
        public string Coddip;
        
        /// <remarks/>
        public string Note;
        
        /// <remarks/>
        public Attivita[] AttivitaSvolte;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://srv.anm.it/npk")]
    public partial class Attivita {
        
        /// <remarks/>
        public int Id;
        
        /// <remarks/>
        public string Descrizione;
        
        /// <remarks/>
        public string Tipo;
        
        /// <remarks/>
        public string IndiceProduzione;
        
        /// <remarks/>
        public int OreEsecuzione;
        
        /// <remarks/>
        public System.DateTime DataEsecuzione;
        
        /// <remarks/>
        public bool Completata;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://srv.anm.it/npk")]
    public partial class Impianti {
        
        /// <remarks/>
        public string Id;
        
        /// <remarks/>
        public string Localizzazione;
        
        /// <remarks/>
        public string Latitudine;
        
        /// <remarks/>
        public string Longitudine;
        
        /// <remarks/>
        public string Descrizione;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://srv.anm.it/npk")]
    public partial class Commesse {
        
        /// <remarks/>
        public int Id;
        
        /// <remarks/>
        public Impianti Impianto;
        
        /// <remarks/>
        public TipoCommessa Tipo;
        
        /// <remarks/>
        public System.DateTime DataCreazione;
        
        /// <remarks/>
        public System.DateTime DataLimite;
        
        /// <remarks/>
        public System.DateTime DataChiusura;
        
        /// <remarks/>
        public string Richiedente;
        
        /// <remarks/>
        public string Descrizione;
        
        /// <remarks/>
        public Operatore[] Operatori;
        
        /// <remarks/>
        public StatoCommessa Stato;
        
        /// <remarks/>
        public Attivita[] Lavori;
        
        /// <remarks/>
        public string UteteUltimaModifica;
        
        /// <remarks/>
        public System.DateTime DataUltimeModifica;
        
        /// <remarks/>
        public string TerminaleUltimaModifica;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://srv.anm.it/npk")]
    public enum TipoCommessa {
        
        /// <remarks/>
        Programmata,
        
        /// <remarks/>
        Urgente,
        
        /// <remarks/>
        Sopralluogo,
        
        /// <remarks/>
        RichiestaIntervento,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://srv.anm.it/npk")]
    public enum StatoCommessa {
        
        /// <remarks/>
        Aperta,
        
        /// <remarks/>
        Chiusa,
        
        /// <remarks/>
        AttesaRiscontro,
        
        /// <remarks/>
        Lavorazione,
        
        /// <remarks/>
        Sospesa,
    }
}
