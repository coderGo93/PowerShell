namespace Nutanix.Powershell
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    using System.Linq;
    using System.Collections.Generic;
    /// <summary>
    /// Low-level API implementation for the Nutanix Intentful API service.
    /// </summary>
    public class NutanixIntentfulAPI
    {
        /// <summary>
        /// Together with the AcceptAllCertifications method right
        /// below this causes to bypass errors caused by SLL-Errors.
        /// </summary>
        public static void IgnoreBadCertificates() {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            System.Net.ServicePointManager.CheckCertificateRevocationList = false;
        }

        /// <summary>
        /// In Short: the Method solves the Problem of broken Certificates.
        /// Sometime when requesting Data and the sending Webserverconnection
        /// is based on a SSL Connection, an Error is caused by Servers whoes
        /// Certificate(s) have Errors. Like when the Cert is out of date
        /// and much more... So at this point when calling the method,
        /// this behaviour is prevented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certification"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns>true</returns>
        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors){
         return true;   
        }

        /// <summary>
        /// This operation submits a request to update a IMAGE based on the input parameters.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="body">An intentful representation of a image</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task UpdateImage(string uuid, Nutanix.Powershell.Models.IImageIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//images/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.UpdateImage_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }

        /// <summary>Actual wire call for <see cref="UpdateImage" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task UpdateImage_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>This operation gets a IMAGE.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetImage(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//images/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetImage_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetImage" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetImage_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// This operation gets a list of IMAGEs, allowing for sorting and pagination. Note: Entities that have not been created successfully
        /// are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetImages(Nutanix.Powershell.Models.IImageListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//images/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetImages_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetImages" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetImages_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>This operation submits a request to delete a IMAGE.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteImage(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//images/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteImage_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="DeleteImage" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteImage_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Downloads the image based on the UUID specified.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task Images(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<System.IO.Stream>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//images/"
                        + System.Uri.EscapeDataString(uuid)
                        + "/file"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.Images_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>
        /// This operation gets a list of Tasks, allowing for sorting and pagination. Note: Entities that have not been created successfully
        /// are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetTaskList(Nutanix.Powershell.Models.ITaskListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using (NoSynchronizationContext)
            {
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//tasks/list"
                        ).TrimEnd('?', '&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                // generate request object
                var request = new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if (eventListener.Token.IsCancellationRequested) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if (eventListener.Token.IsCancellationRequested) { return; }
                // make the call
                await this.GetTaskList_Call(request, onOK, onDefault, eventListener, sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetTaskList" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetTaskList_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using (NoSynchronizationContext)
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if (eventListener.Token.IsCancellationRequested) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch (_response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onOK(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        default:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onDefault(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>This operation gets a Task.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetTask(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITask>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using (NoSynchronizationContext)
            {
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//tasks/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?', '&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                // generate request object
                var request = new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if (eventListener.Token.IsCancellationRequested) { return; }
                // make the call
                await this.GetTask_Call(request, onOK, onNotFound, onDefault, eventListener, sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetTask" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetTask_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITask>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using (NoSynchronizationContext)
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if (eventListener.Token.IsCancellationRequested) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch (_response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onOK(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.Task.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        case System.Net.HttpStatusCode.NotFound:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onNotFound(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        default:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onDefault(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Poll for completion of tasks</summary>
        /// <param name="body">Input for a task poll</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewPoll(Nutanix.Powershell.Models.ITaskPollInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskPollResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using (NoSynchronizationContext)
            {
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//tasks/poll"
                        ).TrimEnd('?', '&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                // generate request object
                var request = new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if (eventListener.Token.IsCancellationRequested) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if (eventListener.Token.IsCancellationRequested) { return; }
                // make the call
                await this.NewPoll_Call(request, onOK, onDefault, eventListener, sender);
            }
        }
        /// <summary>Actual wire call for <see cref="NewPoll" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewPoll_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskPollResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using (NoSynchronizationContext)
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if (eventListener.Token.IsCancellationRequested) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch (_response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onOK(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskPollResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        default:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onDefault(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Actual wire call for <see cref="Images" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task Images_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<System.IO.Stream>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,null /* deserializeFromResponse doesn't support 'application/octet-stream' C:\Users\hugo1\Documents\repositories\autorest.incubator\dist\csharp\schema\binary.js*/);
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,null /* deserializeFromResponse doesn't support '-none-' C:\Users\hugo1\Documents\repositories\autorest.incubator\dist\csharp\schema\object.js*/);
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Images are raw ISO, QCOW2, or VMDK files that are uploaded by a user can be attached to a VM. An ISO image is attached
        /// as a virtual CD-ROM drive, and QCOW2 and VMDK files are attached as SCSI disks. An image has to be explicitly added to
        /// the self-service catalog before users can create VMs from it.
        /// </summary>
        /// <param name="body">An intentful representation of a image</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewImage(Nutanix.Powershell.Models.IImageIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//images"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.NewImage_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="NewImage" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewImage_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="NewImage" /> method. Call this like the actual call, but you will get validation events
        /// back.
        /// </summary>
        /// <param name="body">An intentful representation of a image</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewImage_Validate(Nutanix.Powershell.Models.IImageIntentInput body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>
        /// Submits a request to create a task handling image migration operation, returns a task reference. This moves ownership
        /// of images from the PE cluster to PC. Image uuids can be obtained by querying the PE instance to list images on the PE.
        /// In the case where image uuid list is provided as empty, all images on the cluster that are not currently migrated to PC
        /// will be migrated to PC.
        /// </summary>
        /// <param name="body">Specify the cluster and image(s) from the cluster to migrate to PC
        /// </param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewMigrate(Nutanix.Powershell.Models.IImageMigrateInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IProceduralResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IProceduralErrorResponse>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//images/migrate"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.NewMigrate_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="NewMigrate" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewMigrate_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IProceduralResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IProceduralErrorResponse>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ProceduralResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ProceduralErrorResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        
        /// <summary>
        /// This operation gets a list of Access Control Policies, allowing for sorting and pagination. Note: Entities that have not
        /// been created successfully are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task ListOperation(Nutanix.Powershell.Models.IAccessControlPolicyListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IAccessControlPolicyListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IAccessControlPolicyStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        "http://{url}/api/nutanix/v3//access_control_policies/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
               
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ListOperation_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="ListOperation" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListOperation_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IAccessControlPolicyListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IAccessControlPolicyStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.AccessControlPolicyListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.AccessControlPolicyStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="ListOperation" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListOperation_Validate(Nutanix.Powershell.Models.IAccessControlPolicyListMetadata body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>Displays the user currently logged in.</summary>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task Users(System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IUserIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IUserStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        "http://{url}/api/nutanix/v3//users/me"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.Users_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>This operation submits a request to delete a VM.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteVm(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                IgnoreBadCertificates();
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteVm_Call(request,onAccepted,onNotFound,onDefault,eventListener,sender);
            }
        }
        /// <summary>
        /// This operation submits a request to create a VM based on the input parameters.
        /// </summary>
        /// <param name="body">An intentful representation of a vm</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewVm(Nutanix.Powershell.Models.IVmIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                byte[] byteArray;
                
                byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.NewVm_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }


               /// <summary>
        /// This operation submits a request to create a VM based on the input parameters.
        /// </summary>
        /// <param name="body">An intentful representation of a vm</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewVm_Sync(Nutanix.Powershell.Models.IVmIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onOk,System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound,  Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                byte[] byteArray;
                
                byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                // await this.NewVm_Call(request,onAccepted,onDefault,eventListener,sender);
                await this.NewVm_Call_Sync(request, onAccepted, onOk, onDefault, onNotFound, eventListener, sender, credential);

            }
        }
        /// <summary>Actual wire call for <see cref="Users" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task Users_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IUserIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IUserStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.UserIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.UserStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="Users" /> method. Call this like the actual call, but you will get validation events
        /// back.
        /// </summary>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task Users_Validate(Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
            }
        }
        /// <summary>Actual wire call for <see cref="DeleteVm" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteVm_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        case System.Net.HttpStatusCode.NotFound:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onNotFound(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// This operation gets a list of VMs, allowing for sorting and pagination. Note: Entities that have not been created successfully
        /// are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task Vms(Nutanix.Powershell.Models.IVmListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, string username, string password, System.Management.Automation.PSCredential credential, string url)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                // construct URL
                var _url = new System.Uri((
                        $"{url}/api/nutanix/v3//vms/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                
                byte[] byteArray;
                if (credential != null) {
                    byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.UserName}:{CreateString(credential.Password)}");
                } else {
                    byteArray = System.Text.Encoding.ASCII.GetBytes($"{username}:{password}");
                }

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.Vms_Call(request,onOK,onDefault,eventListener,sender);
            }
        }

        /// <summary>This operation gets a VM.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetVm(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                IgnoreBadCertificates();
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
               
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetVm_Call(request,onOK,onNotFound,onDefault,eventListener,sender);
            }
        }
        /// <summary>
        /// This operation gets a list of VMs, allowing for sorting and pagination. Note: Entities that have not been created successfully
        /// are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetVms(Nutanix.Powershell.Models.IVmListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                IgnoreBadCertificates();
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                
                
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetVms_Call(request,onOK,onDefault,eventListener,sender);
            }
        }

        public async System.Threading.Tasks.Task GetVms_All(Nutanix.Powershell.Models.IVmListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResource[]>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {

            // set the body to fetch the first 
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms/list"
                        ).TrimEnd('?','&'));

                var hasNext = true;

                var _itemsPerPage = 100;
                var _totalItems = 0;
                var _offset = 0;

                body.Length = _itemsPerPage;
                body.Offset = _offset;

                List<Nutanix.Powershell.Models.IVmIntentResource> result = new List<Nutanix.Powershell.Models.IVmIntentResource>();
                while (hasNext) {
                
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // generate request object
                    var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                    // set body content
                    request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                    request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");

                    var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                    
                    // make the call                    
                        System.Net.Http.HttpResponseMessage _response = null;
                        try
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                            _response = await sender.SendAsync(request, eventListener);
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            var _contentType = _response.Content.Headers.ContentType?.MediaType;
                            
                            switch ( _response.StatusCode )
                            {
                                case System.Net.HttpStatusCode.OK:
                                {
                                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                    var f = await _response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.VmListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) );
                                    result.AddRange(f.Entities);
                                    _totalItems = f.Metadata.TotalMatches.Value;

                                    _offset += _itemsPerPage;
                                    if (_offset >= _totalItems) {
                                        hasNext = false;
                                    } else {
                                        body.Offset = _offset;
                                        body.Length = _itemsPerPage;
                                    }
                                    break;
                                }
                                default:
                                {
                                    hasNext = false;
                                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                    await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) ));
                                    break;
                                }
                            }
                        }
                        finally
                        {
                            // finally statements
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                            _response?.Dispose();
                            request?.Dispose();
                        }
                    
                }

                System.Func<System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResource[]>> anonfunc = async () => result.ToArray();
                await onOK(null, anonfunc());
                
            }
        }

        /// <summary>Actual wire call for <see cref="Vms" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task Vms_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="Vms" /> method. Call this like the actual call, but you will get validation events back.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task Vms_Validate(Nutanix.Powershell.Models.IVmListMetadata body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
                /// <summary>Actual wire call for <see cref="GetVms" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetVms_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Actual wire call for <see cref="NewVm" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewVm_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Actual wire call for <see cref="NewVm" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewVm_Call_Sync(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onAccepted,System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onOk,  System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {   
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                Nutanix.Powershell.Models.IVmIntentResponse _vmTask = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            _vmTask = await _response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) );
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }

                var retry = new RetryWithExponentialBackoff();
                await retry.RunAsync(async () =>
                {
                     var _task = await GetTaskStatus(_vmTask.Status.ExecutionContext.TaskUuid, eventListener, sender, credential);
                     if (_task.State !=  "SUCCEEDED" || _task.State !=  "FAILED") 
                     {
                        throw new System.ApplicationException("Status is not completed", new System.Exception($"Status is {_task.State}"));
                     } 

                });
                await this.GetVm(_vmTask.Metadata.Uuid, onOk, onNotFound, onDefault, eventListener, sender, credential);
            }
        }
        /// <summary>Actual wire call for <see cref="GetVm" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetVm_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        case System.Net.HttpStatusCode.NotFound:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onNotFound(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        // System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onNotFound,
        internal async System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus> GetTaskStatus(string uuid, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential) {
                // Constant Parameters
            using (NoSynchronizationContext)
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//tasks/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?', '&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if (eventListener.Token.IsCancellationRequested) { return null; }

                // generate request object
                var request = new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if (eventListener.Token.IsCancellationRequested) { return null; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if (eventListener.Token.IsCancellationRequested) { return null; }
                // make the call
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if (eventListener.Token.IsCancellationRequested) { return null; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch (_response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                                return await _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)));
                            }
                        case System.Net.HttpStatusCode.NotFound:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                                // await onNotFound(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        default:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                                // await onDefault(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                               break;
                            }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
                
            }
            return null;
        }

        private static string CreateString(System.Security.SecureString secureString)
        {
            System.IntPtr intPtr = System.IntPtr.Zero;
            if (secureString == null || secureString.Length == 0)
            {
                return string.Empty;
            }
            string result;
            try
            {
                intPtr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
                result = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(intPtr);
            }
            finally
            {       
                if (intPtr != System.IntPtr.Zero)
                {
                    System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(intPtr);
                }
            }      
            return result;
        }
    }


    internal sealed class RetryWithExponentialBackoff
    {
        public readonly int maxRetries, delayMilliseconds, maxDelayMilliseconds;

        public RetryWithExponentialBackoff(int maxRetries = 50,
            int delayMilliseconds = 200,
            int maxDelayMilliseconds = 2000)
        {
            this.maxRetries = maxRetries;
            this.delayMilliseconds = delayMilliseconds;
            this.maxDelayMilliseconds = maxDelayMilliseconds;
        }

        public async System.Threading.Tasks.Task RunAsync(System.Func<System.Threading.Tasks.Task> func)
        {
            ExponentialBackoff backoff = new ExponentialBackoff(this.maxRetries,
                this.delayMilliseconds,
                this.maxDelayMilliseconds);
            retry:
            try
            {
                await func();
            }
            catch (System.Exception ex) when (ex is System.TimeoutException ||
                ex is System.Net.Http.HttpRequestException || ex is System.ApplicationException)
            {
                await backoff.Delay();
                goto retry;
            }
        }
    }

    internal struct ExponentialBackoff
    {
        private readonly int m_maxRetries, m_delayMilliseconds, m_maxDelayMilliseconds;
        private int m_retries, m_pow;

        public ExponentialBackoff(int maxRetries, int delayMilliseconds,
            int maxDelayMilliseconds)
        {
            m_maxRetries = maxRetries;
            m_delayMilliseconds = delayMilliseconds;
            m_maxDelayMilliseconds = maxDelayMilliseconds;
            m_retries = 0;
            m_pow = 1;
        }

        public System.Threading.Tasks.Task Delay()
        {
            if (m_retries == m_maxRetries)
            {
                throw new System.TimeoutException("Max retry attempts exceeded.");
            }
            ++m_retries;
            if (m_retries < 31)
            {
                m_pow = m_pow << 1; // m_pow = Pow(2, m_retries - 1)
            }
            int delay = System.Math.Min(m_delayMilliseconds * (m_pow - 1) / 2,
                m_maxDelayMilliseconds);
            return System.Threading.Tasks.Task.Delay(delay);
        }
    }
}