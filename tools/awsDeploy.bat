@echo off
echo Delete old package
aws s3 rm s3://pubapp/pubapp.zip
echo Deploying package
aws deploy push --application-name PubApp --s3-location s3://pubapp/pubapp.zip --source deploy
echo Creating deployment
aws deploy create-deployment --application-name PubApp --deployment-config-name CodeDeployDefault.OneAtATime --deployment-group-name PubAppGroup --s3-location bucket=pubapp,bundleType=zip,key=pubapp.zip
