#!groovy

final DOCKER_TOOL = 'docker-latest'
final DOCKER_IMAGE = 'microsoft/dotnet'
final PROJECT_PATH = './Xunit.Extensions';
final PROJECT_PATH_OBJ = PROJECT_PATH+ '/obj';
final PROJECT_PATH_BIN = PROJECT_PATH+ '/bin';

node('docker') {

  /* Requires the Docker Pipeline plugin to be installed */
  withDockerContainer(image: DOCKER_IMAGE, toolName: DOCKER_TOOL) {

      env.HOME = '/tmp/'
      env.PATH = '/usr/bin:${env.PATH}'

      stage('EchoEnv') {
        echo sh(returnStdout: true, script: 'env')
      }

      stage('CheckDependencies') {
        sh "dotnet --version"
      }

      stage('Checkout') {
        checkout scm
      }
	  
	  	stage('Clean') {
	     sh "rm "+PROJECT_PATH_OBJ+" -f --recursive" //https://github.com/dotnet/sdk/issues/1321
		 sh "rm "+TEST_PROJECT_PATH_OBJ+" -f --recursive" //https://github.com/dotnet/sdk/issues/1321
         sh "dotnet clean"
         sh "rm "+PROJECT_PATH_BIN -f --recursive"
      }

      stage('InstallDependencies') {
        sh "dotnet restore"
      }

      stage('Package') {
        sh "dotnet pack --configuration Release"
      }

      if(env.BRANCH_NAME == 'master'){
        stage('Publish') {
          withCredentials([string(credentialsId: 'crc-nuget-releases-api-key', variable: 'NUGET_API_KEY')]) {
            sh "dotnet nuget push ./Xunit.Extensions/bin/Release/*.nupkg -k $NUGET_API_KEY -s http://maven.crcit.es/nexus/service/local/nuget/crc-nuget-releases/ "
          }
        }
      }

  }
}
