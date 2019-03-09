namespace Skydeo.Application.UseCases
{
    public interface IUseCase<in TInput, out TOutput>
    {
        TOutput Execute(TInput input); 
    }
}