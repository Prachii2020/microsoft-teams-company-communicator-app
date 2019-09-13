﻿// <copyright file="Startup.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

[assembly: Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup(
    typeof(Microsoft.Teams.Apps.CompanyCommunicator.Send.Func.Startup))]

namespace Microsoft.Teams.Apps.CompanyCommunicator.Send.Func
{
    using System.IO;
    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories.NotificationData;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories.TeamData;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories.UserData;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Services.AdaptiveCard;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Services.MessageQueue;
    using Microsoft.Teams.Apps.CompanyCommunicator.Send.Func.DeliveryPretreatment;

    /// <summary>
    /// Register services in DI container of the Azure functions system.
    /// </summary>
    public class Startup : FunctionsStartup
    {
        /// <inheritdoc/>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<DeliveryPretreatment.DeliveryPretreatmentOrchestration>();

            builder.Services.AddTransient<MetadataProvider>();

            builder.Services.AddTransient<AdaptiveCardCreator>();

            builder.Services.AddTransient<NotificationDataRepository>();

            builder.Services.AddTransient<SendingNotificationDataRepository>();

            builder.Services.AddTransient<UserDataRepository>();

            builder.Services.AddTransient<TeamDataRepository>();

            builder.Services.AddTransient<TableRowKeyGenerator>();

            builder.Services.AddTransient<SendQueue>();

            builder.Services.AddTransient<DataQueue>();

            builder.Services.AddTransient<GetAudienceDataListActivity>();

            builder.Services.AddTransient<MoveDraftToSentNotificationPartitionActivity>();

            builder.Services.AddTransient<CreateSendingNotificationActivity>();

            builder.Services.AddTransient<SendTriggerToDataFunctionActivity>();

            builder.Services.AddTransient<SendTriggersToSendFunctionActivity>();
        }
    }
}