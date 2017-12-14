const $textarea = $('#content')

$('.icon').on('click', ctx => {
    let icon = $(ctx.target).data('icon')
    $textarea.val(`${$textarea.val()} ${icon} `)
})
