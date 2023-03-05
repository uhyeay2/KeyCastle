﻿namespace KeyCastle.DapperPort.Abstraction
{
    public interface IDapperRequest
    {
        public object? GetParameters();

        public string GetSql();
    }

    public interface IDapperRequest<TResponse> : IDapperRequest { }
}
