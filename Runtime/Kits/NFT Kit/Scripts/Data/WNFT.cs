using Newtonsoft.Json;
namespace Data.Objects
{
    [System.Serializable]
    public class WNFT
    {
        public string name;
        public string image;
        public Properties properties;
    }
    [System.Serializable]
    public class Properties
    {
        public string Level { get; set; }
        public string Life;
        public string HP;
        public string XP;
        [JsonProperty("Well-being")]
        public string Wellbeing;
        [JsonProperty("Favorite Health App")]
        public string FavoriteHealthApp;
        [JsonProperty("Name")]
        public string Name;
        [JsonProperty("Favorite Song")]
        public string FavoriteSong;
        [JsonProperty("Occupation")]
        public string Occupation;
        [JsonProperty("Spiritual Affiliation")]
        public string SpiritualAffiliation;
        [JsonProperty("Fitness Preference")]
        public string FitnessPreference;
        [JsonProperty("Nutritional Type")]
        public string NutrionalType;
        [JsonProperty("Social Preference")]
        public string SocialPreference;
    }
}