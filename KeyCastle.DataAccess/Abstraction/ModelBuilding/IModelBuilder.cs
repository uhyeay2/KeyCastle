namespace KeyCastle.DataAccess.Abstraction.ModelBuilding
{
    internal interface IModelBuilder<TInput, TOutput>
    {
        public TOutput Build(TInput input);
    }
}
