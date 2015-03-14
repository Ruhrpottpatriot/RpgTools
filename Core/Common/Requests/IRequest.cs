// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRequest.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common.Requests
{
    public interface IRequest<out TData>
    {
        TData Resource { get; }
    }
}
