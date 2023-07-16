
const thumb = document.getElementById('likeDislike');
thumb.onclick=toggleLikes;
function toggleLikes() {
    const icon = document.getElementById('thumbIcon');
    icon.classList.toggle('fa-thumbs-up');
    icon.classList.toggle('fa-thumbs-down');  
}
