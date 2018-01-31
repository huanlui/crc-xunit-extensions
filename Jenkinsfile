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
          sh "cd Xunit.Extensions/bin/Debug"
          sh "ls"
          sh "dotnet nuget push *.nupkg -k 9d6c9695-483c-3fca-90f4-f3c79e6d0319 -s http://maven.crcit.es/nexus/service/local/nuget/crc-nuget-releases/ "
        }
      }

  }
}
