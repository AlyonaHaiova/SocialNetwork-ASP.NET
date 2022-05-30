namespace SocialNetwork.Mappers.Abstract
{

    public interface IGenericMapper<TEntity, TModel>
    {
        TEntity ToEntity(TModel model);

        TModel ToModel(TEntity entity);
    }
}