using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendEvaluation.API.Extensions;

namespace BackendEvaluation.API.Controllers.Base;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[ServiceFilter(typeof(RequestLoggingActivityAttribute))]
public abstract class BaseApiController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
