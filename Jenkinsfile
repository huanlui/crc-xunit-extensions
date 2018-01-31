#!groovy

final DOCKER_TOOL = 'docker-latest'
final DOCKER_IMAGE = 'microsoft/dotnet'

node('docker') {

  /* Requires the Docker Pipeline plugin to be installed */
  withDockerContainer(image: DOCKER_IMAGE, toolName: DOCKER_TOOL) {

      /* Set HOME to our current directory because npm and other bower nonsense breaks with HOME=/, e.g.: EACCES: permission denied, mkdir '/.config' */
      env.HOME = '/tmp/'

      stage('EchoEnv') {
        echo sh(returnStdout: true, script: 'env')
      }

      stage('CheckDependencies') {
        sh "/usr/bin/dotnet -v"
      }

      // stage('Checkout') {
      //   checkout scm
      // }

      // stage('Clean') {
      //   sh "rm -f ./package-lock.json"
      //   //sh "rm -f ./yarn.lock"
      // }

      // stage('InstallDependencies') {
      //   sh "yarn install"
      //   ng ("-v");
      // }

      // stage('Test') {
      //   try {
      //     sh "npm run test:ci"
      //   }
      //   catch (Exception err) {
      //     throw err
      //   }
      //   finally {
      //     try {
      //       junit allowEmptyResults: true, testResults: '**/test-jasmine-results.xml'
      //       publishHTML([allowMissing: true, alwaysLinkToLastBuild: true, keepAll: false, reportDir: 'coverage', reportFiles: 'index.html', reportName: 'Coverage Report'])
      //     }
      //     finally { }
      //   }
      // }

      // stage('Build') {
      //   sh "npm run build:all"
      // }

      // stage('Package') {
      //   sh "npm run electron:only-package:linux"
      // }

      // stage('Archive') {
      //   archiveArtifacts artifacts: '**/deploy/installers/**/*.zip', onlyIfSuccessful: true
      // }

  }
}
