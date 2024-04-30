using Amazon.SimpleSystemsManagement.Model;
using Amazon.SimpleSystemsManagement;

namespace postcard.Controllers
{
    public class AwsParameterStorage
    {
        private static string _connectionString = "";
        private static string _bucketname = "";
        private static string _awsAccessKey = "";
        private static string _awsSecretAccessKey = "";

        public static async Task<string> getconnectionstring(IConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(_connectionString))
                return _connectionString;

            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "SQLDatabaseConnection"
            };

            var value = await client.GetParameterAsync(request);

            _connectionString = value.Parameter.Value;
            return _connectionString;
            //return configuration.GetValue<string>("ConnectionStrings:SQLDatabaseConnection");
        }

        public static async Task<string> BucketName(IConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(_bucketname))
                return _bucketname;

            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "BucketName"
            };
            var value = await client.GetParameterAsync(request);
            _bucketname = value.Parameter.Value;

            return _bucketname;
            //return configuration.GetValue<string>("StorageS3:BucketName");
        }

        public static async Task<string> AwsAccessKey(IConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(_awsAccessKey))
                return _awsAccessKey;

            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "AccessKey"
            };
            var value = await client.GetParameterAsync(request);
            _awsAccessKey = value.Parameter.Value;

            return _awsAccessKey;
            //return configuration.GetValue<string>("StorageS3:AwsAccessKey");
        }

        public static async Task<string> AwsSecretAccessKey(IConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(_awsSecretAccessKey))
                return _awsSecretAccessKey;

            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "SecretAccessKey"
            };
            var value = await client.GetParameterAsync(request);
            _awsSecretAccessKey = value.Parameter.Value;
            return _awsSecretAccessKey;

            //return configuration.GetValue<string>("StorageS3:AwsSecretAccessKey");
        }

        public static async Task<List<string>> getstorageconnectionstring(IConfiguration configuration)
        {
            // TODO; mudanças aqui
            var connectionString = await getconnectionstring(configuration);
            var bucketName = await BucketName(configuration);
            var awsAccessKey = await AwsAccessKey(configuration);
            var awsSecretAccessKey = await AwsSecretAccessKey(configuration);

            var storageparams = new List<string>();

            storageparams.Add(connectionString);
            storageparams.Add(bucketName);
            storageparams.Add(awsAccessKey);
            storageparams.Add(awsSecretAccessKey);

            return storageparams;
        }
    }
}
