﻿

using Wallet.Hub.WebApi.Entity;

namespace Wallet.Hub.WebApi.Infrastructure
{
    public interface IVerifyRequestLogRepo
    {
        void Insert(VerifyRequestLog verifyrequestlog);
    }
}