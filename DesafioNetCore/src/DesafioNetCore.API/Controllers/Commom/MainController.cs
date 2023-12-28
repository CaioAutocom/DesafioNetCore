using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DesafioNetCore.API.Controllers;
[ApiController] // Essa decoração libera a documentação dos schemas da aplicação
public abstract class MainController : Controller
{
    protected ICollection<string> Errors = new List<string>();

    protected ActionResult CustomResponse(object result = null)
    {
        if (IsValidOperation())
        {
            return Ok(result);
        }
        // ValidationProblemDetails Essa classe implementa um padrão especificado numa RFC de como uma API deve responder quando há erros
        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>{
            { "Messages", Errors.ToArray() },
        }));
    }
    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(x => x.Errors);

        foreach (var error in errors)
        {
            AddErros(error.ErrorMessage);
        }

        return CustomResponse();
    }


    protected bool IsValidOperation()
    {
        return !Errors.Any();
    }
    protected void AddErros(string error) => Errors.Add(error);
    protected void ClearErrors() => Errors.Clear();

}
