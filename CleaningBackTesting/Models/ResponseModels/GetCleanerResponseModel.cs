namespace CleaningBackTesting.Models.ResponseModels
{
    public class GetCleanerResponseModel : CleanerResponseModelBase
    {
        public override bool Equals(object? obj)
        {
            return obj is GetCleanerResponseModel model &&
                FirstName == model.FirstName &&
                LastName == model.LastName &&
                Phone == model.Phone &&
                Email == model.Email &&
                Rating == model.Rating;
        }

        public override string ToString()
        {
            return FirstName;
        }
    }
}
