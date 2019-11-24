/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Defines a webhook and returns a unique webhook URL generated by CodePipeline. This
    /// URL can be supplied to third party source hosting providers to call every time there's
    /// a code change. When CodePipeline receives a POST request on this URL, the pipeline
    /// defined in the webhook is started as long as the POST request satisfied the authentication
    /// and filtering requirements supplied when defining the webhook. RegisterWebhookWithThirdParty
    /// and DeregisterWebhookWithThirdParty APIs can be used to automatically configure supported
    /// third parties to call the generated webhook URL.
    /// </summary>
    [Cmdlet("Write", "CPWebhook", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodePipeline.Model.ListWebhookItem")]
    [AWSCmdlet("Calls the AWS CodePipeline PutWebhook API operation.", Operation = new[] {"PutWebhook"}, SelectReturnType = typeof(Amazon.CodePipeline.Model.PutWebhookResponse))]
    [AWSCmdletOutput("Amazon.CodePipeline.Model.ListWebhookItem or Amazon.CodePipeline.Model.PutWebhookResponse",
        "This cmdlet returns an Amazon.CodePipeline.Model.ListWebhookItem object.",
        "The service call response (type Amazon.CodePipeline.Model.PutWebhookResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCPWebhookCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        #region Parameter AuthenticationConfiguration_AllowedIPRange
        /// <summary>
        /// <para>
        /// <para>The property used to configure acceptance of webhooks in an IP address range. For
        /// IP, only the <code>AllowedIPRange</code> property must be set. This property must
        /// be set to a valid CIDR range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Webhook_AuthenticationConfiguration_AllowedIPRange")]
        public System.String AuthenticationConfiguration_AllowedIPRange { get; set; }
        #endregion
        
        #region Parameter Webhook_Authentication
        /// <summary>
        /// <para>
        /// <para>Supported options are GITHUB_HMAC, IP, and UNAUTHENTICATED.</para><ul><li><para>For information about the authentication scheme implemented by GITHUB_HMAC, see <a href="https://developer.github.com/webhooks/securing/">Securing your webhooks</a>
        /// on the GitHub Developer website.</para></li><li><para> IP rejects webhooks trigger requests unless they originate from an IP address in
        /// the IP range whitelisted in the authentication configuration.</para></li><li><para> UNAUTHENTICATED accepts all webhook trigger requests regardless of origin.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodePipeline.WebhookAuthenticationType")]
        public Amazon.CodePipeline.WebhookAuthenticationType Webhook_Authentication { get; set; }
        #endregion
        
        #region Parameter Webhook_Filter
        /// <summary>
        /// <para>
        /// <para>A list of rules applied to the body/payload sent in the POST request to a webhook
        /// URL. All defined rules must pass for the request to be accepted and the pipeline started.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Webhook_Filters")]
        public Amazon.CodePipeline.Model.WebhookFilterRule[] Webhook_Filter { get; set; }
        #endregion
        
        #region Parameter Webhook_Name
        /// <summary>
        /// <para>
        /// <para>The name of the webhook.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Webhook_Name { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfiguration_SecretToken
        /// <summary>
        /// <para>
        /// <para>The property used to configure GitHub authentication. For GITHUB_HMAC, only the <code>SecretToken</code>
        /// property must be set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Webhook_AuthenticationConfiguration_SecretToken")]
        public System.String AuthenticationConfiguration_SecretToken { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the webhook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CodePipeline.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Webhook_TargetAction
        /// <summary>
        /// <para>
        /// <para>The name of the action in a pipeline you want to connect to the webhook. The action
        /// must be from the source (first) stage of the pipeline.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Webhook_TargetAction { get; set; }
        #endregion
        
        #region Parameter Webhook_TargetPipeline
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline you want to connect to the webhook.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Webhook_TargetPipeline { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Webhook'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodePipeline.Model.PutWebhookResponse).
        /// Specifying the name of a property of type Amazon.CodePipeline.Model.PutWebhookResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Webhook";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Webhook_Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Webhook_Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Webhook_Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Webhook_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPWebhook (PutWebhook)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodePipeline.Model.PutWebhookResponse, WriteCPWebhookCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Webhook_Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CodePipeline.Model.Tag>(this.Tag);
            }
            context.Webhook_Authentication = this.Webhook_Authentication;
            #if MODULAR
            if (this.Webhook_Authentication == null && ParameterWasBound(nameof(this.Webhook_Authentication)))
            {
                WriteWarning("You are passing $null as a value for parameter Webhook_Authentication which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthenticationConfiguration_AllowedIPRange = this.AuthenticationConfiguration_AllowedIPRange;
            context.AuthenticationConfiguration_SecretToken = this.AuthenticationConfiguration_SecretToken;
            if (this.Webhook_Filter != null)
            {
                context.Webhook_Filter = new List<Amazon.CodePipeline.Model.WebhookFilterRule>(this.Webhook_Filter);
            }
            #if MODULAR
            if (this.Webhook_Filter == null && ParameterWasBound(nameof(this.Webhook_Filter)))
            {
                WriteWarning("You are passing $null as a value for parameter Webhook_Filter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Webhook_Name = this.Webhook_Name;
            #if MODULAR
            if (this.Webhook_Name == null && ParameterWasBound(nameof(this.Webhook_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Webhook_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Webhook_TargetAction = this.Webhook_TargetAction;
            #if MODULAR
            if (this.Webhook_TargetAction == null && ParameterWasBound(nameof(this.Webhook_TargetAction)))
            {
                WriteWarning("You are passing $null as a value for parameter Webhook_TargetAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Webhook_TargetPipeline = this.Webhook_TargetPipeline;
            #if MODULAR
            if (this.Webhook_TargetPipeline == null && ParameterWasBound(nameof(this.Webhook_TargetPipeline)))
            {
                WriteWarning("You are passing $null as a value for parameter Webhook_TargetPipeline which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodePipeline.Model.PutWebhookRequest();
            
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Webhook
            var requestWebhookIsNull = true;
            request.Webhook = new Amazon.CodePipeline.Model.WebhookDefinition();
            Amazon.CodePipeline.WebhookAuthenticationType requestWebhook_webhook_Authentication = null;
            if (cmdletContext.Webhook_Authentication != null)
            {
                requestWebhook_webhook_Authentication = cmdletContext.Webhook_Authentication;
            }
            if (requestWebhook_webhook_Authentication != null)
            {
                request.Webhook.Authentication = requestWebhook_webhook_Authentication;
                requestWebhookIsNull = false;
            }
            List<Amazon.CodePipeline.Model.WebhookFilterRule> requestWebhook_webhook_Filter = null;
            if (cmdletContext.Webhook_Filter != null)
            {
                requestWebhook_webhook_Filter = cmdletContext.Webhook_Filter;
            }
            if (requestWebhook_webhook_Filter != null)
            {
                request.Webhook.Filters = requestWebhook_webhook_Filter;
                requestWebhookIsNull = false;
            }
            System.String requestWebhook_webhook_Name = null;
            if (cmdletContext.Webhook_Name != null)
            {
                requestWebhook_webhook_Name = cmdletContext.Webhook_Name;
            }
            if (requestWebhook_webhook_Name != null)
            {
                request.Webhook.Name = requestWebhook_webhook_Name;
                requestWebhookIsNull = false;
            }
            System.String requestWebhook_webhook_TargetAction = null;
            if (cmdletContext.Webhook_TargetAction != null)
            {
                requestWebhook_webhook_TargetAction = cmdletContext.Webhook_TargetAction;
            }
            if (requestWebhook_webhook_TargetAction != null)
            {
                request.Webhook.TargetAction = requestWebhook_webhook_TargetAction;
                requestWebhookIsNull = false;
            }
            System.String requestWebhook_webhook_TargetPipeline = null;
            if (cmdletContext.Webhook_TargetPipeline != null)
            {
                requestWebhook_webhook_TargetPipeline = cmdletContext.Webhook_TargetPipeline;
            }
            if (requestWebhook_webhook_TargetPipeline != null)
            {
                request.Webhook.TargetPipeline = requestWebhook_webhook_TargetPipeline;
                requestWebhookIsNull = false;
            }
            Amazon.CodePipeline.Model.WebhookAuthConfiguration requestWebhook_webhook_AuthenticationConfiguration = null;
            
             // populate AuthenticationConfiguration
            var requestWebhook_webhook_AuthenticationConfigurationIsNull = true;
            requestWebhook_webhook_AuthenticationConfiguration = new Amazon.CodePipeline.Model.WebhookAuthConfiguration();
            System.String requestWebhook_webhook_AuthenticationConfiguration_authenticationConfiguration_AllowedIPRange = null;
            if (cmdletContext.AuthenticationConfiguration_AllowedIPRange != null)
            {
                requestWebhook_webhook_AuthenticationConfiguration_authenticationConfiguration_AllowedIPRange = cmdletContext.AuthenticationConfiguration_AllowedIPRange;
            }
            if (requestWebhook_webhook_AuthenticationConfiguration_authenticationConfiguration_AllowedIPRange != null)
            {
                requestWebhook_webhook_AuthenticationConfiguration.AllowedIPRange = requestWebhook_webhook_AuthenticationConfiguration_authenticationConfiguration_AllowedIPRange;
                requestWebhook_webhook_AuthenticationConfigurationIsNull = false;
            }
            System.String requestWebhook_webhook_AuthenticationConfiguration_authenticationConfiguration_SecretToken = null;
            if (cmdletContext.AuthenticationConfiguration_SecretToken != null)
            {
                requestWebhook_webhook_AuthenticationConfiguration_authenticationConfiguration_SecretToken = cmdletContext.AuthenticationConfiguration_SecretToken;
            }
            if (requestWebhook_webhook_AuthenticationConfiguration_authenticationConfiguration_SecretToken != null)
            {
                requestWebhook_webhook_AuthenticationConfiguration.SecretToken = requestWebhook_webhook_AuthenticationConfiguration_authenticationConfiguration_SecretToken;
                requestWebhook_webhook_AuthenticationConfigurationIsNull = false;
            }
             // determine if requestWebhook_webhook_AuthenticationConfiguration should be set to null
            if (requestWebhook_webhook_AuthenticationConfigurationIsNull)
            {
                requestWebhook_webhook_AuthenticationConfiguration = null;
            }
            if (requestWebhook_webhook_AuthenticationConfiguration != null)
            {
                request.Webhook.AuthenticationConfiguration = requestWebhook_webhook_AuthenticationConfiguration;
                requestWebhookIsNull = false;
            }
             // determine if request.Webhook should be set to null
            if (requestWebhookIsNull)
            {
                request.Webhook = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CodePipeline.Model.PutWebhookResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.PutWebhookRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "PutWebhook");
            try
            {
                #if DESKTOP
                return client.PutWebhook(request);
                #elif CORECLR
                return client.PutWebhookAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<Amazon.CodePipeline.Model.Tag> Tag { get; set; }
            public Amazon.CodePipeline.WebhookAuthenticationType Webhook_Authentication { get; set; }
            public System.String AuthenticationConfiguration_AllowedIPRange { get; set; }
            public System.String AuthenticationConfiguration_SecretToken { get; set; }
            public List<Amazon.CodePipeline.Model.WebhookFilterRule> Webhook_Filter { get; set; }
            public System.String Webhook_Name { get; set; }
            public System.String Webhook_TargetAction { get; set; }
            public System.String Webhook_TargetPipeline { get; set; }
            public System.Func<Amazon.CodePipeline.Model.PutWebhookResponse, WriteCPWebhookCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Webhook;
        }
        
    }
}