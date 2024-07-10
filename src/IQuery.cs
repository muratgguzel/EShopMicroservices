using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BuidingBlocks.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
	
}
