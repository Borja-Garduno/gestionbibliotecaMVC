﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gestionbibliotecaMVC.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AutorWS", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class AutorWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.AutorServiceOldSoap")]
    public interface AutorServiceOldSoap {
        
        // CODEGEN: Generating message contract since element name GetAutorByIdResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAutorById", ReplyAction="*")]
        gestionbibliotecaMVC.ServiceReference1.GetAutorByIdResponse GetAutorById(gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAutorById", ReplyAction="*")]
        System.Threading.Tasks.Task<gestionbibliotecaMVC.ServiceReference1.GetAutorByIdResponse> GetAutorByIdAsync(gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAutorByIdRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAutorById", Namespace="http://tempuri.org/", Order=0)]
        public gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequestBody Body;
        
        public GetAutorByIdRequest() {
        }
        
        public GetAutorByIdRequest(gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetAutorByIdRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int codAutor;
        
        public GetAutorByIdRequestBody() {
        }
        
        public GetAutorByIdRequestBody(int codAutor) {
            this.codAutor = codAutor;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAutorByIdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAutorByIdResponse", Namespace="http://tempuri.org/", Order=0)]
        public gestionbibliotecaMVC.ServiceReference1.GetAutorByIdResponseBody Body;
        
        public GetAutorByIdResponse() {
        }
        
        public GetAutorByIdResponse(gestionbibliotecaMVC.ServiceReference1.GetAutorByIdResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetAutorByIdResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public gestionbibliotecaMVC.ServiceReference1.AutorWS GetAutorByIdResult;
        
        public GetAutorByIdResponseBody() {
        }
        
        public GetAutorByIdResponseBody(gestionbibliotecaMVC.ServiceReference1.AutorWS GetAutorByIdResult) {
            this.GetAutorByIdResult = GetAutorByIdResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AutorServiceOldSoapChannel : gestionbibliotecaMVC.ServiceReference1.AutorServiceOldSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AutorServiceOldSoapClient : System.ServiceModel.ClientBase<gestionbibliotecaMVC.ServiceReference1.AutorServiceOldSoap>, gestionbibliotecaMVC.ServiceReference1.AutorServiceOldSoap {
        
        public AutorServiceOldSoapClient() {
        }
        
        public AutorServiceOldSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AutorServiceOldSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AutorServiceOldSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AutorServiceOldSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        gestionbibliotecaMVC.ServiceReference1.GetAutorByIdResponse gestionbibliotecaMVC.ServiceReference1.AutorServiceOldSoap.GetAutorById(gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequest request) {
            return base.Channel.GetAutorById(request);
        }
        
        public gestionbibliotecaMVC.ServiceReference1.AutorWS GetAutorById(int codAutor) {
            gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequest inValue = new gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequest();
            inValue.Body = new gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequestBody();
            inValue.Body.codAutor = codAutor;
            gestionbibliotecaMVC.ServiceReference1.GetAutorByIdResponse retVal = ((gestionbibliotecaMVC.ServiceReference1.AutorServiceOldSoap)(this)).GetAutorById(inValue);
            return retVal.Body.GetAutorByIdResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<gestionbibliotecaMVC.ServiceReference1.GetAutorByIdResponse> gestionbibliotecaMVC.ServiceReference1.AutorServiceOldSoap.GetAutorByIdAsync(gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequest request) {
            return base.Channel.GetAutorByIdAsync(request);
        }
        
        public System.Threading.Tasks.Task<gestionbibliotecaMVC.ServiceReference1.GetAutorByIdResponse> GetAutorByIdAsync(int codAutor) {
            gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequest inValue = new gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequest();
            inValue.Body = new gestionbibliotecaMVC.ServiceReference1.GetAutorByIdRequestBody();
            inValue.Body.codAutor = codAutor;
            return ((gestionbibliotecaMVC.ServiceReference1.AutorServiceOldSoap)(this)).GetAutorByIdAsync(inValue);
        }
    }
}
