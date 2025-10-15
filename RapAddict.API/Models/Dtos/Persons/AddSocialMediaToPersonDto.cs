namespace RapAddict.API.Models.Dtos.Persons
{
    public class AddSocialMediaToPersonDto
    {
        public int SocialMediaId { get; }
        public string PlatformId { get; }


        public AddSocialMediaToPersonDto(int socialMediaId, string platformId)
        {
            SocialMediaId = socialMediaId;
            PlatformId = platformId;
        }
    }
}
