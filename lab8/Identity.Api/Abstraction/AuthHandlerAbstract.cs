using Identity.Api.Interfaces;
using MediatR;

namespace Identity.Api.Abstraction;

public abstract class AuthHandlerAbstract<TRequest, TResponce> : IRequestHandler<TRequest, TResponce>
    where TResponce : IAuthResponse, new()
    where TRequest : IRequest<TResponce>

{
    public abstract Task<TResponce> Handle(TRequest request, CancellationToken cancellationToken);

    protected static TResponce Ok(string accessToken, string refreshToken)
    {
        return new TResponce
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            IsSucceed = true
        };
    }

    protected static TResponce Bad(IEnumerable<string> errors)
    {
        return new TResponce
        {
            Errors = errors,
            IsSucceed = false
        };
    }
}