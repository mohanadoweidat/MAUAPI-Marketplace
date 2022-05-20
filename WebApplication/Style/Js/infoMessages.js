function emptyFields() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Please fill all the fields!'
    })
}


function errorLogin() {
    Swal.fire({
        icon: 'error',
        title: 'Wrong...!',
        text: 'Please check your information or your connection!'
    })
}


function sendMessage() {
    Swal.fire(
        'Thank you!',
        'Your message has been sent!',
        'success'
    )
}
 
function UsernameExist() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Youe username does already exist, please login!',
        footer: '<a href="Login.aspx">Login?</a>'
    })
}


function signUpSuccess() {
    Swal.fire({
        icon: 'success',
        title: 'Info',
        text: 'Your account has been created!',
        footer: '<a href="Login.aspx">Login?</a>'
    })
}

function addProductSuccess() {
    Swal.fire({
        icon: 'success',
        title: 'Info',
        text: 'Your product has been listed for selling!',
        footer: '<a href="Userproduct.aspx">See my products</a>'
    })
}


function ErrorDelete() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'You can not delete this product, there is a buy request connected to it!'
        
    })
}


function logInFirst() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'You must log in to continue!',
        footer: '<a href="Login.aspx">Login</a>'
    })
}


function addProductCartSuccess() {
    Swal.fire({
        icon: 'success',
        title: 'Info',
        text: 'The product has been added to your cart!'
        
    })
}

function productExistInCart() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'The product you want to add is already in your cart!',
        footer: '<a href="UserCart.aspx">My cart</a>'
    })
}


function productOrdered() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'The products you trying to order has been already ordered!',
        footer: '<a href="UserOrders.aspx">Order other products / or check your order status?</a>'
    })
}


function noOrdersFound() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'There is no order/s during the selected date period.',
     })
}


function InvalidEmail() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Plese enter a valid email.',
    })
}


function addInterestSuccess() {
    Swal.fire({
        icon: 'success',
        title: 'Info',
        text: 'Your interest has been added!'

    })
}


function InterestAlreadyExist() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'You already registerd this product type.',
    })
}



