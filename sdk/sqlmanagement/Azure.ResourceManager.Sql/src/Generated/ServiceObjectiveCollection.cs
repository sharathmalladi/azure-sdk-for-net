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

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of ServiceObjective and their operations over its parent. </summary>
    public partial class ServiceObjectiveCollection : ArmCollection, IEnumerable<ServiceObjective>, IAsyncEnumerable<ServiceObjective>
    {
        private readonly ClientDiagnostics _serviceObjectiveClientDiagnostics;
        private readonly ServiceObjectivesRestOperations _serviceObjectiveRestClient;

        /// <summary> Initializes a new instance of the <see cref="ServiceObjectiveCollection"/> class for mocking. </summary>
        protected ServiceObjectiveCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ServiceObjectiveCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ServiceObjectiveCollection(ArmResource parent) : base(parent)
        {
            _serviceObjectiveClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ServiceObjective.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(ServiceObjective.ResourceType, out string serviceObjectiveApiVersion);
            _serviceObjectiveRestClient = new ServiceObjectivesRestOperations(_serviceObjectiveClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, serviceObjectiveApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlServer.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlServer.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/serviceObjectives/{serviceObjectiveName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}
        /// OperationId: ServiceObjectives_Get
        /// <summary> Gets a database service objective. </summary>
        /// <param name="serviceObjectiveName"> The name of the service objective to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="serviceObjectiveName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceObjectiveName"/> is null. </exception>
        public virtual Response<ServiceObjective> Get(string serviceObjectiveName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serviceObjectiveName, nameof(serviceObjectiveName));

            using var scope = _serviceObjectiveClientDiagnostics.CreateScope("ServiceObjectiveCollection.Get");
            scope.Start();
            try
            {
                var response = _serviceObjectiveRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, serviceObjectiveName, cancellationToken);
                if (response.Value == null)
                    throw _serviceObjectiveClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServiceObjective(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/serviceObjectives/{serviceObjectiveName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}
        /// OperationId: ServiceObjectives_Get
        /// <summary> Gets a database service objective. </summary>
        /// <param name="serviceObjectiveName"> The name of the service objective to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="serviceObjectiveName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceObjectiveName"/> is null. </exception>
        public async virtual Task<Response<ServiceObjective>> GetAsync(string serviceObjectiveName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serviceObjectiveName, nameof(serviceObjectiveName));

            using var scope = _serviceObjectiveClientDiagnostics.CreateScope("ServiceObjectiveCollection.Get");
            scope.Start();
            try
            {
                var response = await _serviceObjectiveRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, serviceObjectiveName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _serviceObjectiveClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ServiceObjective(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="serviceObjectiveName"> The name of the service objective to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="serviceObjectiveName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceObjectiveName"/> is null. </exception>
        public virtual Response<ServiceObjective> GetIfExists(string serviceObjectiveName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serviceObjectiveName, nameof(serviceObjectiveName));

            using var scope = _serviceObjectiveClientDiagnostics.CreateScope("ServiceObjectiveCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _serviceObjectiveRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, serviceObjectiveName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ServiceObjective>(null, response.GetRawResponse());
                return Response.FromValue(new ServiceObjective(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="serviceObjectiveName"> The name of the service objective to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="serviceObjectiveName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceObjectiveName"/> is null. </exception>
        public async virtual Task<Response<ServiceObjective>> GetIfExistsAsync(string serviceObjectiveName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serviceObjectiveName, nameof(serviceObjectiveName));

            using var scope = _serviceObjectiveClientDiagnostics.CreateScope("ServiceObjectiveCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _serviceObjectiveRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, serviceObjectiveName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ServiceObjective>(null, response.GetRawResponse());
                return Response.FromValue(new ServiceObjective(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="serviceObjectiveName"> The name of the service objective to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="serviceObjectiveName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceObjectiveName"/> is null. </exception>
        public virtual Response<bool> Exists(string serviceObjectiveName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serviceObjectiveName, nameof(serviceObjectiveName));

            using var scope = _serviceObjectiveClientDiagnostics.CreateScope("ServiceObjectiveCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(serviceObjectiveName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="serviceObjectiveName"> The name of the service objective to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="serviceObjectiveName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceObjectiveName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string serviceObjectiveName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serviceObjectiveName, nameof(serviceObjectiveName));

            using var scope = _serviceObjectiveClientDiagnostics.CreateScope("ServiceObjectiveCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(serviceObjectiveName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/serviceObjectives
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}
        /// OperationId: ServiceObjectives_ListByServer
        /// <summary> Returns database service objectives. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceObjective" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServiceObjective> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ServiceObjective> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serviceObjectiveClientDiagnostics.CreateScope("ServiceObjectiveCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serviceObjectiveRestClient.ListByServer(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServiceObjective(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/serviceObjectives
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}
        /// OperationId: ServiceObjectives_ListByServer
        /// <summary> Returns database service objectives. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServiceObjective" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServiceObjective> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ServiceObjective>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serviceObjectiveClientDiagnostics.CreateScope("ServiceObjectiveCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serviceObjectiveRestClient.ListByServerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServiceObjective(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        IEnumerator<ServiceObjective> IEnumerable<ServiceObjective>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ServiceObjective> IAsyncEnumerable<ServiceObjective>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
