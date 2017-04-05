﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PCRemoter.PCRemoterServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PCRemoterServer.IRemoterService")]
    public interface IRemoterService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IRemoterService/DoWork", ReplyAction="http://tempuri.org/IRemoterService/DoWorkResponse")]
        System.IAsyncResult BeginDoWork(System.AsyncCallback callback, object asyncState);
        
        void EndDoWork(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IRemoterService/Hello", ReplyAction="http://tempuri.org/IRemoterService/HelloResponse")]
        System.IAsyncResult BeginHello(System.AsyncCallback callback, object asyncState);
        
        string EndHello(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IRemoterService/Echo", ReplyAction="http://tempuri.org/IRemoterService/EchoResponse")]
        System.IAsyncResult BeginEcho(string _message, System.AsyncCallback callback, object asyncState);
        
        string EndEcho(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IRemoterService/TestConnection", ReplyAction="http://tempuri.org/IRemoterService/TestConnectionResponse")]
        System.IAsyncResult BeginTestConnection(System.AsyncCallback callback, object asyncState);
        
        string EndTestConnection(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IRemoterService/Controls", ReplyAction="http://tempuri.org/IRemoterService/ControlsResponse")]
        System.IAsyncResult BeginControls(string _buttonName, System.AsyncCallback callback, object asyncState);
        
        string EndControls(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IRemoterService/SendTextToWindow", ReplyAction="http://tempuri.org/IRemoterService/SendTextToWindowResponse")]
        System.IAsyncResult BeginSendTextToWindow(string _text, System.AsyncCallback callback, object asyncState);
        
        string EndSendTextToWindow(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRemoterServiceChannel : PCRemoter.PCRemoterServer.IRemoterService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HelloCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public HelloCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EchoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public EchoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TestConnectionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public TestConnectionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ControlsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ControlsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SendTextToWindowCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SendTextToWindowCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RemoterServiceClient : System.ServiceModel.ClientBase<PCRemoter.PCRemoterServer.IRemoterService>, PCRemoter.PCRemoterServer.IRemoterService {
        
        private BeginOperationDelegate onBeginDoWorkDelegate;
        
        private EndOperationDelegate onEndDoWorkDelegate;
        
        private System.Threading.SendOrPostCallback onDoWorkCompletedDelegate;
        
        private BeginOperationDelegate onBeginHelloDelegate;
        
        private EndOperationDelegate onEndHelloDelegate;
        
        private System.Threading.SendOrPostCallback onHelloCompletedDelegate;
        
        private BeginOperationDelegate onBeginEchoDelegate;
        
        private EndOperationDelegate onEndEchoDelegate;
        
        private System.Threading.SendOrPostCallback onEchoCompletedDelegate;
        
        private BeginOperationDelegate onBeginTestConnectionDelegate;
        
        private EndOperationDelegate onEndTestConnectionDelegate;
        
        private System.Threading.SendOrPostCallback onTestConnectionCompletedDelegate;
        
        private BeginOperationDelegate onBeginControlsDelegate;
        
        private EndOperationDelegate onEndControlsDelegate;
        
        private System.Threading.SendOrPostCallback onControlsCompletedDelegate;
        
        private BeginOperationDelegate onBeginSendTextToWindowDelegate;
        
        private EndOperationDelegate onEndSendTextToWindowDelegate;
        
        private System.Threading.SendOrPostCallback onSendTextToWindowCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public RemoterServiceClient() : 
                base(RemoterServiceClient.GetDefaultBinding(), RemoterServiceClient.GetDefaultEndpointAddress()) {
        }
        
        public RemoterServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(RemoterServiceClient.GetBindingForEndpoint(endpointConfiguration), RemoterServiceClient.GetEndpointAddress(endpointConfiguration)) {
        }
        
        public RemoterServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(RemoterServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
        }
        
        public RemoterServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(RemoterServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
        }
        
        public RemoterServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Не удается задать CookieContainer. Проверьте, что привязка содержит HttpCookieCon" +
                            "tainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DoWorkCompleted;
        
        public event System.EventHandler<HelloCompletedEventArgs> HelloCompleted;
        
        public event System.EventHandler<EchoCompletedEventArgs> EchoCompleted;
        
        public event System.EventHandler<TestConnectionCompletedEventArgs> TestConnectionCompleted;
        
        public event System.EventHandler<ControlsCompletedEventArgs> ControlsCompleted;
        
        public event System.EventHandler<SendTextToWindowCompletedEventArgs> SendTextToWindowCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PCRemoter.PCRemoterServer.IRemoterService.BeginDoWork(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDoWork(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void PCRemoter.PCRemoterServer.IRemoterService.EndDoWork(System.IAsyncResult result) {
            base.Channel.EndDoWork(result);
        }
        
        private System.IAsyncResult OnBeginDoWork(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((PCRemoter.PCRemoterServer.IRemoterService)(this)).BeginDoWork(callback, asyncState);
        }
        
        private object[] OnEndDoWork(System.IAsyncResult result) {
            ((PCRemoter.PCRemoterServer.IRemoterService)(this)).EndDoWork(result);
            return null;
        }
        
        private void OnDoWorkCompleted(object state) {
            if ((this.DoWorkCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DoWorkCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DoWorkAsync() {
            this.DoWorkAsync(null);
        }
        
        public void DoWorkAsync(object userState) {
            if ((this.onBeginDoWorkDelegate == null)) {
                this.onBeginDoWorkDelegate = new BeginOperationDelegate(this.OnBeginDoWork);
            }
            if ((this.onEndDoWorkDelegate == null)) {
                this.onEndDoWorkDelegate = new EndOperationDelegate(this.OnEndDoWork);
            }
            if ((this.onDoWorkCompletedDelegate == null)) {
                this.onDoWorkCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDoWorkCompleted);
            }
            base.InvokeAsync(this.onBeginDoWorkDelegate, null, this.onEndDoWorkDelegate, this.onDoWorkCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PCRemoter.PCRemoterServer.IRemoterService.BeginHello(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginHello(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string PCRemoter.PCRemoterServer.IRemoterService.EndHello(System.IAsyncResult result) {
            return base.Channel.EndHello(result);
        }
        
        private System.IAsyncResult OnBeginHello(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((PCRemoter.PCRemoterServer.IRemoterService)(this)).BeginHello(callback, asyncState);
        }
        
        private object[] OnEndHello(System.IAsyncResult result) {
            string retVal = ((PCRemoter.PCRemoterServer.IRemoterService)(this)).EndHello(result);
            return new object[] {
                    retVal};
        }
        
        private void OnHelloCompleted(object state) {
            if ((this.HelloCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.HelloCompleted(this, new HelloCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void HelloAsync() {
            this.HelloAsync(null);
        }
        
        public void HelloAsync(object userState) {
            if ((this.onBeginHelloDelegate == null)) {
                this.onBeginHelloDelegate = new BeginOperationDelegate(this.OnBeginHello);
            }
            if ((this.onEndHelloDelegate == null)) {
                this.onEndHelloDelegate = new EndOperationDelegate(this.OnEndHello);
            }
            if ((this.onHelloCompletedDelegate == null)) {
                this.onHelloCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnHelloCompleted);
            }
            base.InvokeAsync(this.onBeginHelloDelegate, null, this.onEndHelloDelegate, this.onHelloCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PCRemoter.PCRemoterServer.IRemoterService.BeginEcho(string _message, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginEcho(_message, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string PCRemoter.PCRemoterServer.IRemoterService.EndEcho(System.IAsyncResult result) {
            return base.Channel.EndEcho(result);
        }
        
        private System.IAsyncResult OnBeginEcho(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string _message = ((string)(inValues[0]));
            return ((PCRemoter.PCRemoterServer.IRemoterService)(this)).BeginEcho(_message, callback, asyncState);
        }
        
        private object[] OnEndEcho(System.IAsyncResult result) {
            string retVal = ((PCRemoter.PCRemoterServer.IRemoterService)(this)).EndEcho(result);
            return new object[] {
                    retVal};
        }
        
        private void OnEchoCompleted(object state) {
            if ((this.EchoCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.EchoCompleted(this, new EchoCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void EchoAsync(string _message) {
            this.EchoAsync(_message, null);
        }
        
        public void EchoAsync(string _message, object userState) {
            if ((this.onBeginEchoDelegate == null)) {
                this.onBeginEchoDelegate = new BeginOperationDelegate(this.OnBeginEcho);
            }
            if ((this.onEndEchoDelegate == null)) {
                this.onEndEchoDelegate = new EndOperationDelegate(this.OnEndEcho);
            }
            if ((this.onEchoCompletedDelegate == null)) {
                this.onEchoCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnEchoCompleted);
            }
            base.InvokeAsync(this.onBeginEchoDelegate, new object[] {
                        _message}, this.onEndEchoDelegate, this.onEchoCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PCRemoter.PCRemoterServer.IRemoterService.BeginTestConnection(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginTestConnection(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string PCRemoter.PCRemoterServer.IRemoterService.EndTestConnection(System.IAsyncResult result) {
            return base.Channel.EndTestConnection(result);
        }
        
        private System.IAsyncResult OnBeginTestConnection(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((PCRemoter.PCRemoterServer.IRemoterService)(this)).BeginTestConnection(callback, asyncState);
        }
        
        private object[] OnEndTestConnection(System.IAsyncResult result) {
            string retVal = ((PCRemoter.PCRemoterServer.IRemoterService)(this)).EndTestConnection(result);
            return new object[] {
                    retVal};
        }
        
        private void OnTestConnectionCompleted(object state) {
            if ((this.TestConnectionCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.TestConnectionCompleted(this, new TestConnectionCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void TestConnectionAsync() {
            this.TestConnectionAsync(null);
        }
        
        public void TestConnectionAsync(object userState) {
            if ((this.onBeginTestConnectionDelegate == null)) {
                this.onBeginTestConnectionDelegate = new BeginOperationDelegate(this.OnBeginTestConnection);
            }
            if ((this.onEndTestConnectionDelegate == null)) {
                this.onEndTestConnectionDelegate = new EndOperationDelegate(this.OnEndTestConnection);
            }
            if ((this.onTestConnectionCompletedDelegate == null)) {
                this.onTestConnectionCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnTestConnectionCompleted);
            }
            base.InvokeAsync(this.onBeginTestConnectionDelegate, null, this.onEndTestConnectionDelegate, this.onTestConnectionCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PCRemoter.PCRemoterServer.IRemoterService.BeginControls(string _buttonName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginControls(_buttonName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string PCRemoter.PCRemoterServer.IRemoterService.EndControls(System.IAsyncResult result) {
            return base.Channel.EndControls(result);
        }
        
        private System.IAsyncResult OnBeginControls(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string _buttonName = ((string)(inValues[0]));
            return ((PCRemoter.PCRemoterServer.IRemoterService)(this)).BeginControls(_buttonName, callback, asyncState);
        }
        
        private object[] OnEndControls(System.IAsyncResult result) {
            string retVal = ((PCRemoter.PCRemoterServer.IRemoterService)(this)).EndControls(result);
            return new object[] {
                    retVal};
        }
        
        private void OnControlsCompleted(object state) {
            if ((this.ControlsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ControlsCompleted(this, new ControlsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ControlsAsync(string _buttonName) {
            this.ControlsAsync(_buttonName, null);
        }
        
        public void ControlsAsync(string _buttonName, object userState) {
            if ((this.onBeginControlsDelegate == null)) {
                this.onBeginControlsDelegate = new BeginOperationDelegate(this.OnBeginControls);
            }
            if ((this.onEndControlsDelegate == null)) {
                this.onEndControlsDelegate = new EndOperationDelegate(this.OnEndControls);
            }
            if ((this.onControlsCompletedDelegate == null)) {
                this.onControlsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnControlsCompleted);
            }
            base.InvokeAsync(this.onBeginControlsDelegate, new object[] {
                        _buttonName}, this.onEndControlsDelegate, this.onControlsCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PCRemoter.PCRemoterServer.IRemoterService.BeginSendTextToWindow(string _text, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSendTextToWindow(_text, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string PCRemoter.PCRemoterServer.IRemoterService.EndSendTextToWindow(System.IAsyncResult result) {
            return base.Channel.EndSendTextToWindow(result);
        }
        
        private System.IAsyncResult OnBeginSendTextToWindow(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string _text = ((string)(inValues[0]));
            return ((PCRemoter.PCRemoterServer.IRemoterService)(this)).BeginSendTextToWindow(_text, callback, asyncState);
        }
        
        private object[] OnEndSendTextToWindow(System.IAsyncResult result) {
            string retVal = ((PCRemoter.PCRemoterServer.IRemoterService)(this)).EndSendTextToWindow(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSendTextToWindowCompleted(object state) {
            if ((this.SendTextToWindowCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SendTextToWindowCompleted(this, new SendTextToWindowCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SendTextToWindowAsync(string _text) {
            this.SendTextToWindowAsync(_text, null);
        }
        
        public void SendTextToWindowAsync(string _text, object userState) {
            if ((this.onBeginSendTextToWindowDelegate == null)) {
                this.onBeginSendTextToWindowDelegate = new BeginOperationDelegate(this.OnBeginSendTextToWindow);
            }
            if ((this.onEndSendTextToWindowDelegate == null)) {
                this.onEndSendTextToWindowDelegate = new EndOperationDelegate(this.OnEndSendTextToWindow);
            }
            if ((this.onSendTextToWindowCompletedDelegate == null)) {
                this.onSendTextToWindowCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSendTextToWindowCompleted);
            }
            base.InvokeAsync(this.onBeginSendTextToWindowDelegate, new object[] {
                        _text}, this.onEndSendTextToWindowDelegate, this.onSendTextToWindowCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override PCRemoter.PCRemoterServer.IRemoterService CreateChannel() {
            return new RemoterServiceClientChannel(this);
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.NetHttpBinding_IRemoterService)) {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                result.Elements.Add(new System.ServiceModel.Channels.BinaryMessageEncodingBindingElement());
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.NetHttpBinding_IRemoterService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:5051/RemoterService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return RemoterServiceClient.GetBindingForEndpoint(EndpointConfiguration.NetHttpBinding_IRemoterService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return RemoterServiceClient.GetEndpointAddress(EndpointConfiguration.NetHttpBinding_IRemoterService);
        }
        
        private class RemoterServiceClientChannel : ChannelBase<PCRemoter.PCRemoterServer.IRemoterService>, PCRemoter.PCRemoterServer.IRemoterService {
            
            public RemoterServiceClientChannel(System.ServiceModel.ClientBase<PCRemoter.PCRemoterServer.IRemoterService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginDoWork(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("DoWork", _args, callback, asyncState);
                return _result;
            }
            
            public void EndDoWork(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("DoWork", _args, result);
            }
            
            public System.IAsyncResult BeginHello(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("Hello", _args, callback, asyncState);
                return _result;
            }
            
            public string EndHello(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("Hello", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginEcho(string _message, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = _message;
                System.IAsyncResult _result = base.BeginInvoke("Echo", _args, callback, asyncState);
                return _result;
            }
            
            public string EndEcho(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("Echo", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginTestConnection(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("TestConnection", _args, callback, asyncState);
                return _result;
            }
            
            public string EndTestConnection(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("TestConnection", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginControls(string _buttonName, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = _buttonName;
                System.IAsyncResult _result = base.BeginInvoke("Controls", _args, callback, asyncState);
                return _result;
            }
            
            public string EndControls(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("Controls", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginSendTextToWindow(string _text, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = _text;
                System.IAsyncResult _result = base.BeginInvoke("SendTextToWindow", _args, callback, asyncState);
                return _result;
            }
            
            public string EndSendTextToWindow(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("SendTextToWindow", _args, result)));
                return _result;
            }
        }
        
        public enum EndpointConfiguration {
            
            NetHttpBinding_IRemoterService,
        }
    }
}
