﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.296
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pe.Edu.Upc.NTravel.Service.SOAHotel {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://service.company.pe.com/", ConfigurationName="SOAHotel.HotelService")]
    public interface HotelService {
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        Pe.Edu.Upc.NTravel.Service.SOAHotel.ConsultarDisponibilidadResponse ConsultarDisponibilidad(Pe.Edu.Upc.NTravel.Service.SOAHotel.ConsultarDisponibilidad request);
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service.company.pe.com/")]
    public partial class hotel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int camasField;
        
        private int categoriaField;
        
        private int codigoField;
        
        private double costoField;
        
        private string descripcionField;
        
        private string logoField;
        
        private string nombreField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int camas {
            get {
                return this.camasField;
            }
            set {
                this.camasField = value;
                this.RaisePropertyChanged("camas");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public int categoria {
            get {
                return this.categoriaField;
            }
            set {
                this.categoriaField = value;
                this.RaisePropertyChanged("categoria");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public int codigo {
            get {
                return this.codigoField;
            }
            set {
                this.codigoField = value;
                this.RaisePropertyChanged("codigo");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public double costo {
            get {
                return this.costoField;
            }
            set {
                this.costoField = value;
                this.RaisePropertyChanged("costo");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("descripcion");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string logo {
            get {
                return this.logoField;
            }
            set {
                this.logoField = value;
                this.RaisePropertyChanged("logo");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
                this.RaisePropertyChanged("nombre");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ConsultarDisponibilidad", WrapperNamespace="http://service.company.pe.com/", IsWrapped=true)]
    public partial class ConsultarDisponibilidad {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.company.pe.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int cantidadPersona;
        
        public ConsultarDisponibilidad() {
        }
        
        public ConsultarDisponibilidad(int cantidadPersona) {
            this.cantidadPersona = cantidadPersona;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ConsultarDisponibilidadResponse", WrapperNamespace="http://service.company.pe.com/", IsWrapped=true)]
    public partial class ConsultarDisponibilidadResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.company.pe.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public hotel[] @return;
        
        public ConsultarDisponibilidadResponse() {
        }
        
        public ConsultarDisponibilidadResponse(hotel[] @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface HotelServiceChannel : Pe.Edu.Upc.NTravel.Service.SOAHotel.HotelService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HotelServiceClient : System.ServiceModel.ClientBase<Pe.Edu.Upc.NTravel.Service.SOAHotel.HotelService>, Pe.Edu.Upc.NTravel.Service.SOAHotel.HotelService {
        
        public HotelServiceClient() {
        }
        
        public HotelServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HotelServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotelServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotelServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Pe.Edu.Upc.NTravel.Service.SOAHotel.ConsultarDisponibilidadResponse Pe.Edu.Upc.NTravel.Service.SOAHotel.HotelService.ConsultarDisponibilidad(Pe.Edu.Upc.NTravel.Service.SOAHotel.ConsultarDisponibilidad request) {
            return base.Channel.ConsultarDisponibilidad(request);
        }
        
        public hotel[] ConsultarDisponibilidad(int cantidadPersona) {
            Pe.Edu.Upc.NTravel.Service.SOAHotel.ConsultarDisponibilidad inValue = new Pe.Edu.Upc.NTravel.Service.SOAHotel.ConsultarDisponibilidad();
            inValue.cantidadPersona = cantidadPersona;
            Pe.Edu.Upc.NTravel.Service.SOAHotel.ConsultarDisponibilidadResponse retVal = ((Pe.Edu.Upc.NTravel.Service.SOAHotel.HotelService)(this)).ConsultarDisponibilidad(inValue);
            return retVal.@return;
        }
    }
}
