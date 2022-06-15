namespace Identity.Api.Interfaces;

public interface IAuthResponse : ISuccessAuthResponse, IFailedAuthResponse, IStatusAuthResponse
{

}