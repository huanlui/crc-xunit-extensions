#!groovy

final DOCKER_TOOL = 'docker-latest'
final DOCKER_IMAGE = 'microsoft/dotnet'

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

      stage('InstallDependencies') {
        sh "dotnet restore"
      }

      stage('Package') {
        sh "dotnet pack"
      }

      if(env.BRANCH_NAME == 'master'){
        stage('Publish') {
          withCredentials([string(credentialsId: 'crc-nuget-releases-api-key', variable: 'NUGET_API_KEY')]) {
            sh "dotnet nuget push ./Xunit.Extensions/bin/Debug/*.nupkg -k $NUGET_API_KEY -s http://maven.crcit.es/nexus/service/local/nuget/crc-nuget-releases/ "
          }
        }
      }

  }
}
