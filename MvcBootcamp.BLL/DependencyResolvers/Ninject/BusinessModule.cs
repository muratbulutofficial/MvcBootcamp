using Castle.DynamicProxy;
using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.Concrete;
using MvcBootcamp.DAL.Abstract;
using MvcBootcamp.DAL.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            // InSingletonScope() ilgili nesnenin sadece bir kere oluşturulmasını sağlar.
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<IAuthorService>().To<AuthorManager>().InSingletonScope();
            Bind<IAuthorDal>().To<EfAuthorDal>().InSingletonScope();

            Bind<IMessageService>().To<MessageManager>().InSingletonScope();
            Bind<IMessageDal>().To<EfMessageDal>().InSingletonScope();

            Bind<IContentService>().To<ContentManager>().InSingletonScope();
            Bind<IContentDal>().To<EfContentDal>().InSingletonScope();

            Bind<IHeadlineService>().To<HeadlineManager>().InSingletonScope();
            Bind<IHeadlineDal>().To<EfHeadlineDal>().InSingletonScope();

            Bind<IUserLevelService>().To<UserLevelManager>().InSingletonScope();
            Bind<IUserLevelDal>().To<EfUserLevelDal>().InSingletonScope();

            Bind<ISkillService>().To<SkillManager>().InSingletonScope();
            Bind<ISkillDal>().To<EfSkillDal>().InSingletonScope();
        }
    }
}
