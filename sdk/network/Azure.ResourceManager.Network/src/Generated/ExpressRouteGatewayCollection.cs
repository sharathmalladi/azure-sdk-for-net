// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of ExpressRouteGateway and their operations over its parent. </summary>
    public partial class ExpressRouteGatewayCollection : ArmCollection, IEnumerable<ExpressRouteGateway>, IAsyncEnumerable<ExpressRouteGateway>
    {
        private readonly ClientDiagnostics _expressRouteGatewayClientDiagnostics;
        private readonly ExpressRouteGatewaysRestOperations _expressRouteGatewayRestClient;

        /// <summary> Initializes a new instance of the <see cref="ExpressRouteGatewayCollection"/> class for mocking. </summary>
        protected ExpressRouteGatewayCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ExpressRouteGatewayCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExpressRouteGatewayCollection(ArmResource parent) : base(parent)
        {
            _expressRouteGatewayClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ExpressRouteGateway.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(ExpressRouteGateway.ResourceType, out string expressRouteGatewayApiVersion);
            _expressRouteGatewayRestClient = new ExpressRouteGatewaysRestOperations(_expressRouteGatewayClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, expressRouteGatewayApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// <summary> Creates or updates a ExpressRoute gateway in a specified resource group. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="expressRouteGatewayName"> The name of the ExpressRoute gateway. </param>
        /// <param name="putExpressRouteGatewayParameters"> Parameters required in an ExpressRoute gateway PUT operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="expressRouteGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="expressRouteGatewayName"/> or <paramref name="putExpressRouteGatewayParameters"/> is null. </exception>
        public virtual ExpressRouteGatewayCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string expressRouteGatewayName, ExpressRouteGatewayData putExpressRouteGatewayParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRouteGatewayName, nameof(expressRouteGatewayName));
            if (putExpressRouteGatewayParameters == null)
            {
                throw new ArgumentNullException(nameof(putExpressRouteGatewayParameters));
            }

            using var scope = _expressRouteGatewayClientDiagnostics.CreateScope("ExpressRouteGatewayCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _expressRouteGatewayRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, expressRouteGatewayName, putExpressRouteGatewayParameters, cancellationToken);
                var operation = new ExpressRouteGatewayCreateOrUpdateOperation(ArmClient, _expressRouteGatewayClientDiagnostics, Pipeline, _expressRouteGatewayRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, expressRouteGatewayName, putExpressRouteGatewayParameters).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a ExpressRoute gateway in a specified resource group. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="expressRouteGatewayName"> The name of the ExpressRoute gateway. </param>
        /// <param name="putExpressRouteGatewayParameters"> Parameters required in an ExpressRoute gateway PUT operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="expressRouteGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="expressRouteGatewayName"/> or <paramref name="putExpressRouteGatewayParameters"/> is null. </exception>
        public async virtual Task<ExpressRouteGatewayCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string expressRouteGatewayName, ExpressRouteGatewayData putExpressRouteGatewayParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRouteGatewayName, nameof(expressRouteGatewayName));
            if (putExpressRouteGatewayParameters == null)
            {
                throw new ArgumentNullException(nameof(putExpressRouteGatewayParameters));
            }

            using var scope = _expressRouteGatewayClientDiagnostics.CreateScope("ExpressRouteGatewayCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _expressRouteGatewayRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, expressRouteGatewayName, putExpressRouteGatewayParameters, cancellationToken).ConfigureAwait(false);
                var operation = new ExpressRouteGatewayCreateOrUpdateOperation(ArmClient, _expressRouteGatewayClientDiagnostics, Pipeline, _expressRouteGatewayRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, expressRouteGatewayName, putExpressRouteGatewayParameters).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Fetches the details of a ExpressRoute gateway in a resource group. </summary>
        /// <param name="expressRouteGatewayName"> The name of the ExpressRoute gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="expressRouteGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="expressRouteGatewayName"/> is null. </exception>
        public virtual Response<ExpressRouteGateway> Get(string expressRouteGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRouteGatewayName, nameof(expressRouteGatewayName));

            using var scope = _expressRouteGatewayClientDiagnostics.CreateScope("ExpressRouteGatewayCollection.Get");
            scope.Start();
            try
            {
                var response = _expressRouteGatewayRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, expressRouteGatewayName, cancellationToken);
                if (response.Value == null)
                    throw _expressRouteGatewayClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExpressRouteGateway(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Fetches the details of a ExpressRoute gateway in a resource group. </summary>
        /// <param name="expressRouteGatewayName"> The name of the ExpressRoute gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="expressRouteGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="expressRouteGatewayName"/> is null. </exception>
        public async virtual Task<Response<ExpressRouteGateway>> GetAsync(string expressRouteGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRouteGatewayName, nameof(expressRouteGatewayName));

            using var scope = _expressRouteGatewayClientDiagnostics.CreateScope("ExpressRouteGatewayCollection.Get");
            scope.Start();
            try
            {
                var response = await _expressRouteGatewayRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, expressRouteGatewayName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _expressRouteGatewayClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ExpressRouteGateway(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="expressRouteGatewayName"> The name of the ExpressRoute gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="expressRouteGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="expressRouteGatewayName"/> is null. </exception>
        public virtual Response<ExpressRouteGateway> GetIfExists(string expressRouteGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRouteGatewayName, nameof(expressRouteGatewayName));

            using var scope = _expressRouteGatewayClientDiagnostics.CreateScope("ExpressRouteGatewayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _expressRouteGatewayRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, expressRouteGatewayName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ExpressRouteGateway>(null, response.GetRawResponse());
                return Response.FromValue(new ExpressRouteGateway(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="expressRouteGatewayName"> The name of the ExpressRoute gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="expressRouteGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="expressRouteGatewayName"/> is null. </exception>
        public async virtual Task<Response<ExpressRouteGateway>> GetIfExistsAsync(string expressRouteGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRouteGatewayName, nameof(expressRouteGatewayName));

            using var scope = _expressRouteGatewayClientDiagnostics.CreateScope("ExpressRouteGatewayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _expressRouteGatewayRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, expressRouteGatewayName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ExpressRouteGateway>(null, response.GetRawResponse());
                return Response.FromValue(new ExpressRouteGateway(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="expressRouteGatewayName"> The name of the ExpressRoute gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="expressRouteGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="expressRouteGatewayName"/> is null. </exception>
        public virtual Response<bool> Exists(string expressRouteGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRouteGatewayName, nameof(expressRouteGatewayName));

            using var scope = _expressRouteGatewayClientDiagnostics.CreateScope("ExpressRouteGatewayCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(expressRouteGatewayName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="expressRouteGatewayName"> The name of the ExpressRoute gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="expressRouteGatewayName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="expressRouteGatewayName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string expressRouteGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(expressRouteGatewayName, nameof(expressRouteGatewayName));

            using var scope = _expressRouteGatewayClientDiagnostics.CreateScope("ExpressRouteGatewayCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(expressRouteGatewayName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists ExpressRoute gateways in a given resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ExpressRouteGateway" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ExpressRouteGateway> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ExpressRouteGateway> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _expressRouteGatewayClientDiagnostics.CreateScope("ExpressRouteGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _expressRouteGatewayRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ExpressRouteGateway(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary> Lists ExpressRoute gateways in a given resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ExpressRouteGateway" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ExpressRouteGateway> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ExpressRouteGateway>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _expressRouteGatewayClientDiagnostics.CreateScope("ExpressRouteGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _expressRouteGatewayRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ExpressRouteGateway(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        IEnumerator<ExpressRouteGateway> IEnumerable<ExpressRouteGateway>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ExpressRouteGateway> IAsyncEnumerable<ExpressRouteGateway>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
