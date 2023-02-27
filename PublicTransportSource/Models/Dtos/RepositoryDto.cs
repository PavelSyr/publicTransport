public class RepositoryDto<TData>
{
    public TData? Data { get; set; }
    public bool IsSuccess {get; set;} = true;
    public List<string>? ErrorMessages { get; internal set; }
}