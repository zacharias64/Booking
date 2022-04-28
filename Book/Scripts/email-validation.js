var VuePage = new Vue({
  el: '#app',
  data: {
      UserEmail: '',
    reg: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,24}))$/
  },
  methods: {
    isEmailValid: function() {
          return (this.form.UserEmail == "") ? "" : (this.reg.test(this.form.UserEmail)) ? 'has-success' : 'has-error';
    }
  }
});