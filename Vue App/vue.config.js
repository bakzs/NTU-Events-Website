/* Temp solution to fix CORS error in development */
module.exports = {
devServer: {
    // setting host should not be necessary
    // host: '0.0.0.0:8080'
    public: '0.0.0.0:8080',
    disableHostCheck: true
  }
}