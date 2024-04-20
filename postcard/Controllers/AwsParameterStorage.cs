using Amazon.SimpleSystemsManagement.Model;
using Amazon.SimpleSystemsManagement;

namespace postcard.Controllers
{
    public class AwsParameterStorage
    {
        public static async Task<string> getconnectionstring(IConfiguration configuration)
        {
            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "SQLDatabaseConnection"
            };
            var value = await client.GetParameterAsync(request);
            return value.Parameter.Value;
#if DEBUG
            var connectionString = configuration.GetValue<string>("ConnectionStrings:SQLDatabaseConnection");
            return connectionString;
#else
            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "SQLDatabaseConnection"
            };
            var value = await client.GetParameterAsync(request);
            return value.Parameter.Value;
#endif
        }

        public static async Task<string> BucketName(IConfiguration configuration)
        {
            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "BucketName"
            };
            var value = await client.GetParameterAsync(request);
            return value.Parameter.Value;
#if DEBUG
            return configuration.GetValue<string>("StorageS3:BucketName");
#else
            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "BucketName"
            };
            var value = await client.GetParameterAsync(request);
            return value.Parameter.Value;
#endif
        }

        public static async Task<string> AwsAccessKey(IConfiguration configuration)
        {
            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "AccessKey"
            };
            var value = await client.GetParameterAsync(request);
            return value.Parameter.Value;
#if DEBUG
            return configuration.GetValue<string>("StorageS3:AwsAccessKey");
#else
            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "AccessKey"
            };
            var value = await client.GetParameterAsync(request);
            return value.Parameter.Value;
#endif
        }

        public static async Task<string> AwsSecretAccessKey(IConfiguration configuration)
        {
            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "SecretAccessKey"
            };
            var value = await client.GetParameterAsync(request);
            return value.Parameter.Value;
#if DEBUG
            return configuration.GetValue<string>("StorageS3:AwsSecretAccessKey");
#else
            var client = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1);
            var request = new GetParameterRequest()
            {
                Name = "SecretAccessKey"
            };
            var value = await client.GetParameterAsync(request);
            return value.Parameter.Value;
#endif
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