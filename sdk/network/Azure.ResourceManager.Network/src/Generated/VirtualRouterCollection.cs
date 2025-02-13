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
    /// <summary> A class representing collection of VirtualRouter and their operations over its parent. </summary>
    public partial class VirtualRouterCollection : ArmCollection, IEnumerable<VirtualRouter>, IAsyncEnumerable<VirtualRouter>
    {
        private readonly ClientDiagnostics _virtualRouterClientDiagnostics;
        private readonly VirtualRoutersRestOperations _virtualRouterRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualRouterCollection"/> class for mocking. </summary>
        protected VirtualRouterCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualRouterCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualRouterCollection(ArmResource parent) : base(parent)
        {
            _virtualRouterClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", VirtualRouter.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(VirtualRouter.ResourceType, out string virtualRouterApiVersion);
            _virtualRouterRestClient = new VirtualRoutersRestOperations(_virtualRouterClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, virtualRouterApiVersion);
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

        /// <summary> Creates or updates the specified Virtual Router. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualRouterName"> The name of the Virtual Router. </param>
        /// <param name="parameters"> Parameters supplied to the create or update Virtual Router. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualRouterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualRouterName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual VirtualRouterCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string virtualRouterName, VirtualRouterData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualRouterName, nameof(virtualRouterName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualRouterRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, virtualRouterName, parameters, cancellationToken);
                var operation = new VirtualRouterCreateOrUpdateOperation(ArmClient, _virtualRouterClientDiagnostics, Pipeline, _virtualRouterRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualRouterName, parameters).Request, response);
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

        /// <summary> Creates or updates the specified Virtual Router. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualRouterName"> The name of the Virtual Router. </param>
        /// <param name="parameters"> Parameters supplied to the create or update Virtual Router. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualRouterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualRouterName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<VirtualRouterCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string virtualRouterName, VirtualRouterData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualRouterName, nameof(virtualRouterName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualRouterRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualRouterName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new VirtualRouterCreateOrUpdateOperation(ArmClient, _virtualRouterClientDiagnostics, Pipeline, _virtualRouterRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualRouterName, parameters).Request, response);
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

        /// <summary> Gets the specified Virtual Router. </summary>
        /// <param name="virtualRouterName"> The name of the Virtual Router. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualRouterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualRouterName"/> is null. </exception>
        public virtual Response<VirtualRouter> Get(string virtualRouterName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualRouterName, nameof(virtualRouterName));

            using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualRouterRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualRouterName, expand, cancellationToken);
                if (response.Value == null)
                    throw _virtualRouterClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualRouter(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified Virtual Router. </summary>
        /// <param name="virtualRouterName"> The name of the Virtual Router. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualRouterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualRouterName"/> is null. </exception>
        public async virtual Task<Response<VirtualRouter>> GetAsync(string virtualRouterName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualRouterName, nameof(virtualRouterName));

            using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualRouterRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualRouterName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _virtualRouterClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualRouter(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="virtualRouterName"> The name of the Virtual Router. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualRouterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualRouterName"/> is null. </exception>
        public virtual Response<VirtualRouter> GetIfExists(string virtualRouterName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualRouterName, nameof(virtualRouterName));

            using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualRouterRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualRouterName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualRouter>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualRouter(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="virtualRouterName"> The name of the Virtual Router. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualRouterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualRouterName"/> is null. </exception>
        public async virtual Task<Response<VirtualRouter>> GetIfExistsAsync(string virtualRouterName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualRouterName, nameof(virtualRouterName));

            using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualRouterRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualRouterName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualRouter>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualRouter(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="virtualRouterName"> The name of the Virtual Router. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualRouterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualRouterName"/> is null. </exception>
        public virtual Response<bool> Exists(string virtualRouterName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualRouterName, nameof(virtualRouterName));

            using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(virtualRouterName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="virtualRouterName"> The name of the Virtual Router. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualRouterName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualRouterName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string virtualRouterName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualRouterName, nameof(virtualRouterName));

            using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(virtualRouterName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all Virtual Routers in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualRouter" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualRouter> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VirtualRouter> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualRouterRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualRouter(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualRouter> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualRouterRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualRouter(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all Virtual Routers in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualRouter" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualRouter> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualRouter>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualRouterRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualRouter(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualRouter>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualRouterClientDiagnostics.CreateScope("VirtualRouterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualRouterRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualRouter(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<VirtualRouter> IEnumerable<VirtualRouter>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualRouter> IAsyncEnumerable<VirtualRouter>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
