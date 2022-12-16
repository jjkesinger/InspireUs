param (
    [string]$username,
    [string]$password,
    [string]$tenantId,
    [string]$resourceGroupName,
    [string]$subscriptionName,
    [string]$containerRegistryName,
    [string]$location,
    [string]$database,
    [string]$server,    
    [string]$startIp,
    [string]$endIp,
    [string]$dblogin,
    [string]$dbpassword,
    [string]$serviceBusNS
)

# login
Write-Output "Logging in to AZ..."
az login --service-principal -u $username -p $password --tenant $tenantId

# set subscription
Write-Output "Setting subscription $subscriptionName..."
az account set -s $subscriptionName

# create resource group
Write-Output "Creating resource group $resourceGroupName..."
az group create -l $location -n $resourceGroupName

# install aks cli
Write-Output "Installing aks cli..."
az aks install-cli

# enable resource providers
Write-Output "Setting resource providers..."
az provider register --namespace Microsoft.OperationsManagement
az provider register --namespace Microsoft.OperationalInsights

# create azure container registry
Write-Output "Creating container registry $containerRegistryName..."
az acr create —-resource-group $resourceGroupName —-name $containerRegistryName —-sku Basic

#create database
Write-Output "Creating $server in $location..."
az sql server create --name $server --resource-group $resourceGroupName --location "$location" --admin-user $dblogin --admin-password $dbpassword
Write-Output "Configuring firewall..."
az sql server firewall-rule create --resource-group $resourceGroupName --server $server -n AllowYourIp --start-ip-address $startIp --end-ip-address $endIp
Write-Output "Creating $database on $server..."
az sql db create --resource-group $resourceGroupName --server $server --name $database --service-objective Basic --tier Basic

#create service bus queue
Write-Output "Creating service bus..."
az servicebus namespace create --resource-group $resourceGroupName --name $serviceBusNS --location "$location"
Write-Output "Creating SyncQueue..."
az servicebus queue create --resource-group $resourceGroupName --namespace-name $serviceBusNS --name WebScrapingQueue

# how to get sb connectionstring
# az servicebus namespace authorization-rule keys list --resource-group $resourceGroupName --namespace-name $serviceBusNS --name RootManageSharedAccessKey --query primaryConnectionString --output tsv
