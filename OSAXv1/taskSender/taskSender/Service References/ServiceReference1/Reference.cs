﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18063
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace taskSender.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Task", Namespace="http://schemas.datacontract.org/2004/07/taskCatcher.TaskModel")]
    [System.SerializableAttribute()]
    public partial class Task : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private taskSender.ServiceReference1.Element[] affecttedActorsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private taskSender.ServiceReference1.Task.assignemnet assignField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private taskSender.ServiceReference1.Element assistanceObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private taskSender.ServiceReference1.Task.effectiveness effectiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private taskSender.ServiceReference1.Element executorActorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private taskSender.ServiceReference1.Task.involvement involveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string outcomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string taskNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public taskSender.ServiceReference1.Element[] affecttedActors {
            get {
                return this.affecttedActorsField;
            }
            set {
                if ((object.ReferenceEquals(this.affecttedActorsField, value) != true)) {
                    this.affecttedActorsField = value;
                    this.RaisePropertyChanged("affecttedActors");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public taskSender.ServiceReference1.Task.assignemnet assign {
            get {
                return this.assignField;
            }
            set {
                if ((this.assignField.Equals(value) != true)) {
                    this.assignField = value;
                    this.RaisePropertyChanged("assign");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public taskSender.ServiceReference1.Element assistanceObject {
            get {
                return this.assistanceObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.assistanceObjectField, value) != true)) {
                    this.assistanceObjectField = value;
                    this.RaisePropertyChanged("assistanceObject");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public taskSender.ServiceReference1.Task.effectiveness effective {
            get {
                return this.effectiveField;
            }
            set {
                if ((this.effectiveField.Equals(value) != true)) {
                    this.effectiveField = value;
                    this.RaisePropertyChanged("effective");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public taskSender.ServiceReference1.Element executorActor {
            get {
                return this.executorActorField;
            }
            set {
                if ((object.ReferenceEquals(this.executorActorField, value) != true)) {
                    this.executorActorField = value;
                    this.RaisePropertyChanged("executorActor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public taskSender.ServiceReference1.Task.involvement involve {
            get {
                return this.involveField;
            }
            set {
                if ((this.involveField.Equals(value) != true)) {
                    this.involveField = value;
                    this.RaisePropertyChanged("involve");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string outcome {
            get {
                return this.outcomeField;
            }
            set {
                if ((object.ReferenceEquals(this.outcomeField, value) != true)) {
                    this.outcomeField = value;
                    this.RaisePropertyChanged("outcome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string taskName {
            get {
                return this.taskNameField;
            }
            set {
                if ((object.ReferenceEquals(this.taskNameField, value) != true)) {
                    this.taskNameField = value;
                    this.RaisePropertyChanged("taskName");
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
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="Task.assignemnet", Namespace="http://schemas.datacontract.org/2004/07/taskCatcher.TaskModel")]
        public enum assignemnet : int {
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            unassigned = 0,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            assigned = 1,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            nill = 2,
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="Task.effectiveness", Namespace="http://schemas.datacontract.org/2004/07/taskCatcher.TaskModel")]
        public enum effectiveness : int {
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            effective = 0,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            uneffective = 1,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            nill = 2,
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="Task.involvement", Namespace="http://schemas.datacontract.org/2004/07/taskCatcher.TaskModel")]
        public enum involvement : int {
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            indirect = 0,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            direct = 1,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            nill = 2,
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Element", Namespace="http://schemas.datacontract.org/2004/07/taskCatcher.TaskModel")]
    [System.SerializableAttribute()]
    public partial class Element : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string conceptualElementField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string domainElementField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] instancesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string conceptualElement {
            get {
                return this.conceptualElementField;
            }
            set {
                if ((object.ReferenceEquals(this.conceptualElementField, value) != true)) {
                    this.conceptualElementField = value;
                    this.RaisePropertyChanged("conceptualElement");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string domainElement {
            get {
                return this.domainElementField;
            }
            set {
                if ((object.ReferenceEquals(this.domainElementField, value) != true)) {
                    this.domainElementField = value;
                    this.RaisePropertyChanged("domainElement");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] instances {
            get {
                return this.instancesField;
            }
            set {
                if ((object.ReferenceEquals(this.instancesField, value) != true)) {
                    this.instancesField = value;
                    this.RaisePropertyChanged("instances");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ITaskCatcher")]
    public interface ITaskCatcher {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaskCatcher/DoWork", ReplyAction="http://tempuri.org/ITaskCatcher/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaskCatcher/recieveTask", ReplyAction="http://tempuri.org/ITaskCatcher/recieveTaskResponse")]
        string recieveTask(taskSender.ServiceReference1.Task tsk);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaskCatcher/recieveTaskWithWindow", ReplyAction="http://tempuri.org/ITaskCatcher/recieveTaskWithWindowResponse")]
        string recieveTaskWithWindow(taskSender.ServiceReference1.Task tsk, int window);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITaskCatcherChannel : taskSender.ServiceReference1.ITaskCatcher, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaskCatcherClient : System.ServiceModel.ClientBase<taskSender.ServiceReference1.ITaskCatcher>, taskSender.ServiceReference1.ITaskCatcher {
        
        public TaskCatcherClient() {
        }
        
        public TaskCatcherClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TaskCatcherClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskCatcherClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskCatcherClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public string recieveTask(taskSender.ServiceReference1.Task tsk) {
            return base.Channel.recieveTask(tsk);
        }
        
        public string recieveTaskWithWindow(taskSender.ServiceReference1.Task tsk, int window) {
            return base.Channel.recieveTaskWithWindow(tsk, window);
        }
    }
}
