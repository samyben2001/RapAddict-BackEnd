using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class AddSocialMediaToPersonCommand: ICommandDefinition
    {
        public int PersonId { get; }
        public int SocialMediaId { get; }
        public string PlatformId { get; }


        public AddSocialMediaToPersonCommand(int personId, int socialMediaId, string platformId)
        {
            PersonId = personId;
            SocialMediaId = socialMediaId;
            PlatformId = platformId;
        }
    }
}
